using System;
using System.Text;
using System.Text.Json;

using Azure;
using Azure.Core;

using Deveel.Security;
using Deveel.Testing;

using FluentAssertions;

using Microsoft.Extensions.DependencyInjection;

namespace Deveel.Messaging {
	public static class ClientRegistrationTests {
		[Fact]
		public static async Task AddClientCredentialsClient() {
			var clientId = Guid.NewGuid().ToString();
			var clientSecret = Guid.NewGuid().ToString();

			var accessToken = Guid.NewGuid().ToString();
			var expiresIn = TimeSpan.FromSeconds(3600);

			var services = new ServiceCollection()
				.AddOcmClientSettings(settings => settings.UseClientCredentials(clientId, clientSecret, "create:channel", "send:message"))
				.AddServiceClient<TestServiceClient>()
				.AddTestHttpClientFactory(request => {
					var responseContent = new {
						access_token = accessToken,
						expires_in = (int)expiresIn.TotalSeconds
					};

					var responseBytes = JsonSerializer.SerializeToUtf8Bytes(responseContent);

					var content = new StringContent(Encoding.UTF8.GetString(responseBytes), Encoding.UTF8);

					var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK) {
						Content = content
					};

					return Task.FromResult(response);
				})
				//.AddSingleton<IHttpClientFactory>(_ => new OAuthHttpClientFactory(accessToken, expiresIn))
				.BuildServiceProvider();

			var client = services.GetRequiredService<TestServiceClient>();

			client.Should().NotBeNull();
			client.TokenCredential.Should().NotBeNull();
			client.BaseUrl.Should().BeNull();

			var accessTokenResult = await client.TokenCredential.GetTokenAsync(new TokenRequestContext(), default);

			Assert.Equal(accessToken, accessTokenResult.Token);
		}

		[Fact]
		public static async Task AddClientWithStaticAccessToken() {
			var accessToken = Guid.NewGuid().ToString();
			var expiresAt = DateTimeOffset.UtcNow.AddMinutes(20);

			var services = new ServiceCollection()
				.AddOcmClientSettings(settings => settings.UseAccessToken(accessToken, expiresAt))
				.AddServiceClient<TestServiceClient>()
				.BuildServiceProvider();

			var client = services.GetRequiredService<TestServiceClient>();

			client.Should().NotBeNull();
			client.TokenCredential.Should().NotBeNull();
			client.BaseUrl.Should().BeNull();

			var accessTokenResult = await client.TokenCredential.GetTokenAsync(new TokenRequestContext(), default);

			Assert.Equal(accessToken, accessTokenResult.Token);
		}

		[Fact]
		public static async Task AddClientWithAccessTokenReader() {
			var accessToken = Guid.NewGuid().ToString();
			var expiresAt = DateTimeOffset.UtcNow.AddMinutes(20);

			var services = new ServiceCollection()
				.AddOcmClientSettings(settings => settings.UseAccessToken())
				.AddSingleton<IAccessTokenReader>(_ => new TestAccessTokenReader(accessToken, expiresAt))
				.AddServiceClient<TestServiceClient>()
				.BuildServiceProvider();

			var client = services.GetRequiredService<TestServiceClient>();

			client.Should().NotBeNull();
			client.TokenCredential.Should().NotBeNull();
			client.BaseUrl.Should().BeNull();

			var accessTokenResult = await client.TokenCredential.GetTokenAsync(new TokenRequestContext(), default);

			Assert.Equal(accessToken, accessTokenResult.Token);
		}


		[Fact]
		public static void AddApiKeyClient() {
			var apiKey = Guid.NewGuid().ToString();

			var services = new ServiceCollection()
				.AddOcmClientSettings(settings => settings.UseApiKey(apiKey))
				.AddServiceClient<TestServiceClient>()
				.BuildServiceProvider();

			var client = services.GetRequiredService<TestServiceClient>();

			client.Should().NotBeNull();
			client.TokenCredential.Should().BeNull();
			client.ApiKey.Should().NotBeNull();
			client.BaseUrl.Should().BeNull();
		}

		[Fact]
		public static void RegisterDefaultClient() {
			var services = new ServiceCollection()
				.AddOcmClient(builder => builder
					.WithLifetime(ServiceLifetime.Transient)
					.UseSettings(settings => settings.UseAccessToken()))
				.BuildServiceProvider();

			var ocmClient = services.GetRequiredService<IOcmClient>();

			ocmClient.Should().NotBeNull();
			ocmClient.Settings.Should().NotBeNull();
			ocmClient.Services.Should().NotBeNull();
		}

		class TestServiceClient {
			public TestServiceClient(AzureKeyCredential apiKey, Uri? baseUrl = null) {
				ApiKey = apiKey;
				BaseUrl = baseUrl;
			}

			public TestServiceClient(TokenCredential tokenCredential, Uri? baseUrl = null) {
				TokenCredential = tokenCredential;
				BaseUrl = baseUrl;
			}

			public AzureKeyCredential? ApiKey { get; }

			public Uri? BaseUrl { get; }

			public TokenCredential? TokenCredential { get; }
		}

		private class TestAccessTokenReader : IAccessTokenReader {
			private readonly string accessToken;
			private readonly DateTimeOffset expiresAt;

			public TestAccessTokenReader(string accessToken, DateTimeOffset expiresAt) {
				this.accessToken = accessToken;
				this.expiresAt = expiresAt;
			}

			public ValueTask<AccessToken> ReadAccessToken(CancellationToken cancellationToken = default)
				=> ValueTask.FromResult(new AccessToken(accessToken, expiresAt)); 
		}
	}
}
