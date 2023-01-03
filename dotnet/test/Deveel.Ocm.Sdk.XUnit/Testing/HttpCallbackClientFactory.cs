using System;

namespace Deveel.Testing {
	partial class HttpCallbackClientFactory : IHttpClientFactory, IDisposable {
		private readonly IHttpMessageCallback callback;
		private readonly Dictionary<string, HttpClient> clients;

		public HttpCallbackClientFactory(IHttpMessageCallback callback) {
			this.callback = callback;
			clients = new Dictionary<string, HttpClient>();
		}

		public HttpClient CreateClient(string name) {
			if (!clients.TryGetValue(name, out var client)) {
				clients[name] = client = new HttpClient(new HttpCallbackHandler(callback));
			}

			return client;
		}
		
		public void Dispose() {
			foreach (var client in clients) {
				client.Value?.Dispose();
			}

			clients.Clear();
		}
	}
}
