using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace Deveel.Messaging {
	public struct CommandRegistration {
		public CommandRegistration(Type commandType, Type handlerType) : this() {
			if (!typeof(Command).IsAssignableFrom(commandType))
				throw new ArgumentException($"The type '{commandType}' is not a valid command", nameof(commandType));
			if (!typeof(ICommandHandler).IsAssignableFrom(handlerType))
				throw new ArgumentException($"The type '{handlerType}' is not a valid command handler");

			CommandType = commandType ?? throw new ArgumentNullException(nameof(commandType));
			HandlerType = handlerType ?? throw new ArgumentNullException(nameof(handlerType));
		}

		public Type CommandType { get; }

		public Type HandlerType { get; }
	}
}
