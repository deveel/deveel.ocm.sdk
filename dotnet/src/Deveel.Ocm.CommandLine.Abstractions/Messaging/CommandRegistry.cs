using System;
using System.Collections;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace Deveel.Messaging {
	public sealed class CommandRegistry : IEnumerable<CommandRegistration> {
		private readonly List<CommandRegistration> registrations = new List<CommandRegistration>();

		public void AddCommand(CommandRegistration registration) {
			if (registrations.Any(x => x.CommandType == registration.CommandType)) {
				var existing = registrations.Find(x => x.CommandType == registration.CommandType);
				registrations.Remove(registration);
			}

			registrations.Add(registration);
		}

		public void AddCommand<TCommand, THandler>()
			where TCommand : Command
			where THandler : class, ICommandHandler {
			AddCommand(new CommandRegistration(typeof(TCommand), typeof(THandler)));
		}

		public IEnumerator<CommandRegistration> GetEnumerator() {
			return registrations.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
	}
}
