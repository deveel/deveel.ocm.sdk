using System;

using Microsoft.Extensions.DependencyInjection;

namespace Deveel.Messaging {
	public interface IServiceConfigurator {
		void ConfigureServices(IServiceCollection services);
	}
}
