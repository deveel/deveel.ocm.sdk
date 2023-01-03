namespace Deveel.Testing {
	public sealed class HttpCallbackHandler : HttpMessageHandler {
		private IHttpMessageCallback callback;

		public HttpCallbackHandler(IHttpMessageCallback callback) {
			this.callback = callback;
		}

		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
			=> callback.OnSendAsync(request, cancellationToken);

		public static HttpCallbackHandler Create(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> callback)
			=> new HttpCallbackHandler(new DelegatedHttpMessageCallback(callback));

		public static HttpCallbackHandler Create(Func<HttpRequestMessage, Task<HttpResponseMessage>> callback)
			=> new HttpCallbackHandler(new DelegatedHttpMessageCallback(callback));

		public static HttpCallbackHandler Create(Func<HttpRequestMessage, HttpResponseMessage> callback)
			=> new HttpCallbackHandler(new DelegatedHttpMessageCallback(callback));
	}
}