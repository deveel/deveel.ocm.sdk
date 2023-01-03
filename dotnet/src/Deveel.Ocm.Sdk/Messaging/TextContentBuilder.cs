using System;
using System.Text;

namespace Deveel.Messaging {
	public sealed class TextContentBuilder {
		private StringBuilder? content;

		internal TextContentBuilder() {
		}

		public TextContentBuilder Append(string text) {
			if (content == null)
				content = new StringBuilder();

			content.Append(text);

			return this;
		}

		internal TextContent Build() {
			if (content == null || content.Length == 0)
				throw new InvalidOperationException("The content was not set");

			return new TextContent(content.ToString());
		}
	}
}
