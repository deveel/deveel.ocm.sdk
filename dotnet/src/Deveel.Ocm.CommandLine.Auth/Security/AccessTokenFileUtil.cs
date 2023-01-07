using System;
using System.Data.Common;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json;
using System.Text.Json.Nodes;

using Azure.Core;

namespace Deveel.Messaging {
	static class AccessTokenFileUtil {
		private const string FileName = ".ocm_auth";
		private const string AppDirectoryName = ".ocm";
		private const string DeveelDirectoryName = "deveel";

		private static string GetFilePath() {
			if (Environment.OSVersion.Platform == PlatformID.Unix)
				throw new NotSupportedException("Unix systems not supported yet");

			var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			path = Path.Combine(path, DeveelDirectoryName);
			path = Path.Combine(path, AppDirectoryName);

			return Path.Combine(path, FileName);
		}

		private static void EnsureDirectoryExists() {
			var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			var deveelDirPath = Path.Combine(path, DeveelDirectoryName);
			if (!Directory.Exists(deveelDirPath))
				Directory.CreateDirectory(deveelDirPath);

			var ocmDirPath = Path.Combine(deveelDirPath, AppDirectoryName);
			if (!Directory.Exists(ocmDirPath))
				Directory.CreateDirectory(ocmDirPath);
		}

		public static async Task<IList<AccessToken>> FindTokensAsync() {
			var filePath = GetFilePath();

			if (!File.Exists(filePath))
				return new AccessToken[0];

			return await ParseFileAsync(filePath);
		}

		private static async Task<IList<AccessToken>> ParseFileAsync(FileStream fileStream) {
			var doc = await JsonDocument.ParseAsync(fileStream);

			if (doc.RootElement.ValueKind == JsonValueKind.Array) {
				var length = doc.RootElement.GetArrayLength();
				var result = new AccessToken[length];
				for (int i = 0; i < length; i++) {
					result[i] = ParseAccessToken(doc.RootElement[i]);
				}

				return result;
			} else if (doc.RootElement.ValueKind == JsonValueKind.Object) {
				return new[] { ParseAccessToken(doc.RootElement) };
			} else {
				throw new FormatException("Auth file not well formatted");
			}
		}

		private static async Task<IList<AccessToken>> ParseFileAsync(string fileName) {
			using var fileStream = File.OpenRead(fileName);
			return await ParseFileAsync(fileStream);
		}

		private static AccessToken ParseAccessToken(JsonElement jsonElement) {
			if (!jsonElement.TryGetProperty("access_token", out var accessToken))
				throw new FormatException("Could not find the access token");

			DateTimeOffset tokenExpiration;

			if (!jsonElement.TryGetProperty("expires_on", out var expiresOn))
				throw new FormatException("Could not find the expiration date or time in the auth file");

			if (!expiresOn.TryGetDateTimeOffset(out tokenExpiration)) {
				if (!expiresOn.TryGetInt64(out var seconds))
					throw new FormatException("Invalid format of the expires_in property of the auth");

				tokenExpiration = DateTimeOffset.UtcNow.AddSeconds(seconds);
			}

			var accessTokenValue = accessToken.GetString();
			if (String.IsNullOrWhiteSpace(accessTokenValue))
				throw new FormatException("The access_token is empty");

			return new AccessToken(accessTokenValue, tokenExpiration);
		}

		public static async Task SaveTokenAsync(string accessToken, DateTimeOffset expiresOn) {
			var filePath = GetFilePath();

			FileStream? fileStream = null;

			try {
				if (!File.Exists(filePath)) {
					EnsureDirectoryExists();

					fileStream = File.Create(filePath, 512, FileOptions.RandomAccess);
				} else {
					fileStream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
				}

				await SaveTokenToFileAsync(fileStream, accessToken, expiresOn);
			} finally {
				fileStream?.Dispose();
			}
		}

		private static async Task SaveTokenToFileAsync(FileStream fileStream, string accessToken, DateTimeOffset expiresOn) {
			IList<AccessToken> existing;

			if (fileStream.Length > 0) {
				existing = await ParseFileAsync(fileStream);
				fileStream.Seek(0, SeekOrigin.Begin);
			} else {
				existing = new AccessToken[0];
			}

			var newTokens = new List<AccessToken>();
			if (existing.Count > 0) {
				foreach (var item in existing) {
					if (String.Equals(item.Token, accessToken) || 
						item.ExpiresOn >= DateTimeOffset.UtcNow)
						continue;

					newTokens.Add(item);
				}
			}

			newTokens.Add(new AccessToken(accessToken, expiresOn));

			using var jsonWriter = new Utf8JsonWriter(fileStream);
			jsonWriter.WriteStartArray();

			foreach (var item in newTokens) {
				jsonWriter.WriteStartObject();
				jsonWriter.WriteString("access_token", item.Token);
				jsonWriter.WriteString("expires_on", item.ExpiresOn.ToString("O"));
				jsonWriter.WriteEndObject();
			}

			jsonWriter.WriteEndArray();

			await jsonWriter.FlushAsync();
		}
	}
}
