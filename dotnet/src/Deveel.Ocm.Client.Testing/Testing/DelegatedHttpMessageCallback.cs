using System;

namespace Deveel.Testing {
	class DelegatedHttpMessageCallback : IHttpMessageCallback {
		private readonly Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>>? asyncCallback1;
		private readonly Func<HttpRequestMessage, Task<HttpResponseMessage>>? asyncCallback2;
		private readonly Func<HttpRequestMessage, HttpResponseMessage>? syncCallback;

		public DelegatedHttpMessageCallback(Func<HttpRequestMessage, Task<HttpResponseMessage>> asyncCallback2) {
			this.asyncCallback2 = asyncCallback2;
		}

		public DelegatedHttpMessageCallback(Func<HttpRequestMessage, HttpResponseMessage> syncCallback) {
			this.syncCallback = syncCallback;
		}

		public DelegatedHttpMessageCallback(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> callback) {
			asyncCallback1 = callback;
		}

		public async Task<HttpResponseMessage> OnSendAsync(HttpRequestMessage request, CancellationToken cancellationToken = default) {
			if (asyncCallback1 != null)
				return await asyncCallback1(request, cancellationToken);
			if (asyncCallback2 != null)
				return await asyncCallback2(request);
			if (syncCallback != null) {
				return syncCallback(request);
			}

			throw new NotSupportedException();
		}
	}
}
