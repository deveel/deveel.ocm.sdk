using System;

namespace Deveel.Messaging {
	public interface IServiceClientFactory<TClient> where TClient : class {
		TClient CreateClient(ServiceClientContext<TClient> context);
	}
}
