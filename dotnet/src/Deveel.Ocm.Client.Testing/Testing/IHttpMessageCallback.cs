using System;

namespace Deveel.Testing {
	public interface IHttpMessageCallback {
		Task<HttpResponseMessage> OnSendAsync(HttpRequestMessage request, CancellationToken cancellationToken = default);
	}
}
