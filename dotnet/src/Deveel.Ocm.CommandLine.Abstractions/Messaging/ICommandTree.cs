using System;
using System.CommandLine;

namespace Deveel.Messaging {
	public interface ICommandTree {
		void AppendTo(RootCommand root);
	}
}
