using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Transactions;

using Deveel.Messaging.Terminals.Management;
using Deveel.Messaging.Terminals.Management.Models;

using Microsoft.Extensions.DependencyInjection;

namespace Deveel.Messaging.Terminals {
	class NewTerminalCommand : Command {
		static NewTerminalCommand() {
			TypeOption = new Option<ServerTerminalType>(new[] { "--type", "-t" }, "The type of terminal to create") { IsRequired = true };
			AddressOption = new Option<string>(new[] { "--address", "-a" }, "The address/number of the terminal") { IsRequired = true };
			ProviderOption = new Option<string>(new[] { "--provider", "-p" }, "Indicates the code f the provider of the terminal (eg. 'twilio', 'linkmobility', etc.)") { IsRequired = true };
			RolesOption = new Option<TerminalRoles?>(new[] { "--role", "-r" }, "Specifies the role that a terminal can assume in the platform");
		}

		public NewTerminalCommand()
			: base("terminal", "Creates a new terminal in the context of the current tenant") {
			AddOption(TypeOption);
			AddOption(AddressOption);
			AddOption(ProviderOption);
			AddOption(RolesOption);
		}

		private static Option<ServerTerminalType> TypeOption { get; }

		private static Option<string> ProviderOption { get; }

		private static Option<string> AddressOption { get; }

		private static Option<TerminalRoles?> RolesOption { get; }

		public new class Handler : ICommandHandler {
			private readonly TerminalClient client;

			public Handler(TerminalClient client) {
				this.client = client;
			}

			public int Invoke(InvocationContext context) {
				return InvokeAsync(context).ConfigureAwait(false).GetAwaiter().GetResult();
			}

			public async Task<int> InvokeAsync(InvocationContext context) {
				var type = context.ParseResult.GetValueForOption(TypeOption);
				var address = context.ParseResult.GetValueForOption(AddressOption);
				var provider = context.ParseResult.GetValueForOption(ProviderOption);
				var roles = context.ParseResult.GetValueForOption(RolesOption);


				context.Console.WriteLine("");
				context.Console.WriteLine($"Creating the {GetTypeName(type)} '{address}' provided by {provider}");

				var newTerminal = new NewServerTerminal(provider, GetRole(roles), GetType(type), address);

				var result = await client.CreateTerminalAsync(newTerminal, context.GetCancellationToken());

				var json = JsonSerializer.SerializeToDocument(result);

				context.Console.WriteLine("");
				context.Console.WriteLine("The new terminal was created:");
				context.Console.WriteLine(json.ToString());

				return 0;
				
			}

			private static Management.Models.ServerTerminalType GetType(ServerTerminalType type) {
				throw new NotImplementedException();
			}

			private static Management.Models.TerminalRoles GetRole(TerminalRoles? roles) {
				throw new NotImplementedException();
			}

			private string GetTypeName(ServerTerminalType type) {
				return type switch {
					ServerTerminalType.AlphaNumeric => "alpha-numeric",
					ServerTerminalType.PhoneNumber => "phone number",
					ServerTerminalType.Email => "e-mail",
					_ => "terminal"
				};
			}
		}
	}
}
