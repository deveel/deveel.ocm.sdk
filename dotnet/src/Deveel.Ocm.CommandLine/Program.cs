using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Help;
using System.CommandLine.Hosting;
using System.CommandLine.Invocation;
using System.CommandLine.IO;
using System.CommandLine.Parsing;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Hosting;

using Spectre.Console;

namespace Deveel.Messaging {
	public static class Program {
		// TODO:
		private static readonly string Description = "Deveel OCM CLI";

		private static IServiceProvider? stageServiceProvider;

		public static async Task<int> Main(string[] args) {
			var runner = new CommandLineBuilder(BuildCommandTree())
				.UseHost(host => host
					.ConfigureServiceFromContext()
					.ConfigureCommands()
					.ConfigureHostConfiguration(config => Configure(config, args))
					.UseConsoleLifetime())
				.UseDefaults()
				.UseHelp(context => {
					context.HelpBuilder.CustomizeLayout(help => {
						return HelpBuilder.Default.GetLayout().Skip(1).Prepend(_ => {
							AnsiConsole.Write(new FigletText("OCM"));
						});
					});
				})
				.UseVersionOption()
				.UseExceptionHandler(OnException)
				.Build();

			return await runner.InvokeAsync(args);
		}

		private static IServiceProvider GetStagingServices() {
			if (stageServiceProvider == null) {
				var services = new ServiceCollection()
					.Scan(source => source
						.FromApplicationDependencies()
						.AddClasses(t => t.AssignableToAny(typeof(ICommandTree), typeof(IServiceConfigurator), typeof(ICommandProvider)))
						.AsImplementedInterfaces()
						.WithTransientLifetime());

				stageServiceProvider = services.BuildServiceProvider();
			}

			return stageServiceProvider;
		}

		private static IHostBuilder ConfigureServiceFromContext(this IHostBuilder builder) {
			return builder.ConfigureServices(services => {
				var provider = GetStagingServices();
				var configurators = provider.GetServices<IServiceConfigurator>();

				foreach (var configurator in configurators) {
					configurator.ConfigureServices(services);
				}
			});
		}

		private static IHostBuilder ConfigureCommands(this IHostBuilder builder) {
			
			var services = GetStagingServices();
			var commandRegistry = new CommandRegistry();

			var providers = services.GetServices<ICommandProvider>();
			foreach (var provider in providers) {
				provider.RegisterCommands(commandRegistry);
			}

			foreach (var registration in commandRegistry) {
				builder = builder.UseCommandHandler(registration.CommandType, registration.HandlerType);
			}

			return builder;
		}

		private static void Configure(IConfigurationBuilder builder, string[] args) {
			builder.AddEnvironmentVariables();
			builder.AddJsonFile("App.config", true);
			builder.AddCommandLine(args);
		}

		private static void OnException(Exception error, InvocationContext context) {
			context.Console.Error.WriteLine("Error while executing the requested command");

			context.Console.Error.WriteLine(error.Message);

			if (!String.IsNullOrWhiteSpace(error.StackTrace))
				context.Console.Error.WriteLine(error.StackTrace);
		}

		private static RootCommand BuildCommandTree() {
			var services = GetStagingServices();

			var rootCommand = new RootCommand(Description);
			rootCommand.AddCommand(new NewCommand());

			var commandProviders = services.GetServices<ICommandTree>();

			foreach (var commandProvider in commandProviders) {
				commandProvider.AppendTo(rootCommand);
			}

			return rootCommand;
		}
	}
}