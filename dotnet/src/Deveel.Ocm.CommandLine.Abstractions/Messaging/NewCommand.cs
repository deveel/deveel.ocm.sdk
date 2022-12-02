using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.Rendering;
using System.CommandLine.Rendering.Views;

namespace Deveel.Messaging {
	public sealed class NewCommand : Command {
		public NewCommand() : base("new", "Instantiates new items in the platform") {
			ListOption = new Option<bool>(new[] { "--list", "-l" }, "Lists all the available sub-commands for instantiation of entities in the platform");

			AddOption(ListOption);

			this.SetHandler(Execute);
		}

		public Option<bool> ListOption { get; private set; }

		private void Execute(InvocationContext context) {
			if (context.ParseResult.GetValueForOption(ListOption)) {
				var view = new TableView<Command>();
				view.Items = Subcommands;

				view.AddColumn(c => c.Name, "Command", ColumnDefinition.SizeToContent());
				view.AddColumn(c => c.Description, "Description", ColumnDefinition.SizeToContent());

				var stack = new StackLayoutView {
					new ContentView("These are the templates for creating entities in the platform"),
					new ContentView("\n"),
					view,
					new ContentView("\n"),
				};

				stack.Render(new ConsoleRenderer(context.Console, context.BindingContext.OutputMode(), true), Region.Scrolling);
			}
		}
	}
}
