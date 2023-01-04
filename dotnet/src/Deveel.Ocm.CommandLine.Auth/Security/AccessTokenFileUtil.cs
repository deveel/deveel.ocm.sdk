using System;
using System.Data.Common;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json;

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

		public static IList<AccessToken> FindTokens() {
			var filePath = GetFilePath();

			if (!File.Exists(filePath))
				return new AccessToken[0];

			return ParseFile(filePath);
		}

		private static IList<AccessToken> ParseFile(string fileName) {
			using var fileStream = File.OpenRead(fileName);
			var doc = JsonDocument.Parse(fileStream);

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

		private static AccessToken ParseAccessToken(JsonElement jsonElement) {
			if (!jsonElement.TryGetProperty("access_token", out var accessToken))
				throw new FormatException("Could not find the access token");

			DateTimeOffset tokenExpiration;

			if (!jsonElement.TryGetProperty("expires_in", out var expiresIn))
				throw new FormatException("Could not find the expiration date or time in the auth file");

			if (!expiresIn.TryGetDateTimeOffset(out tokenExpiration)) {
				if (!expiresIn.TryGetInt64(out var seconds))
					throw new FormatException("Invalid format of the expires_in property of the auth");

				tokenExpiration = DateTimeOffset.UtcNow.AddSeconds(seconds);
			}

			var accessTokenValue = accessToken.GetString();
			if (String.IsNullOrWhiteSpace(accessTokenValue))
				throw new FormatException("The access_token is empty");

			return new AccessToken(accessTokenValue, tokenExpiration);
		}

		public static Task SaveTokenAsync(string accessToken, DateTimeOffset expiresOn) {
			var filePath = GetFilePath();

			FileStream? fileStream = null;

			try {
				if (!File.Exists(filePath)) {
					fileStream = File.Create(filePath);
				} else {
					fileStream = File.OpenWrite(filePath);
				}

				var doc = JsonDocument.Parse(fileStream);

				throw new NotImplementedException("Implementation not completed");
			} finally {
				fileStream?.Dispose();
			}

			return Task.CompletedTask;
		}
	}
}
