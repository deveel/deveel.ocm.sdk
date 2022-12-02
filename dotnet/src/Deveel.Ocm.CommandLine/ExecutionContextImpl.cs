using System;
using System.CommandLine.Invocation;

using Deveel.Messaging;

using Microsoft.Extensions.Hosting;

namespace Deveel.Ocm.CommandLine {
	internal class ExecutionContextImpl : ICommandExecutionContext {
		private readonly IHost host;
		private readonly InvocationContext context;

		public ExecutionContextImpl(IHost host, InvocationContext context) {
			this.host = host;
			this.context = context;
		}

		public IServiceProvider Services => host.Services;

		public InvocationContext InvocationContext => context;
	}
}
