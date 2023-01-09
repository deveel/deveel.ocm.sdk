using System;

using Deveel.Messaging.Models;

namespace Deveel.Messaging {
	/// <summary>
	/// A message content that is in a plain-text format. 
	/// </summary>
	public sealed class TextContent : MessageContentBase {
		/// <summary>
		/// Constructs the content with the given text
		/// </summary>
		/// <param name="content">The textual content of the message</param>
		/// <exception cref="ArgumentException">
		/// Thrown if the content specified is <c>null</c> or an empty string.
		/// </exception>
		public TextContent(string content) {
			if (string.IsNullOrWhiteSpace(content)) 
				throw new ArgumentException($"'{nameof(content)}' cannot be null or whitespace.", nameof(content));

			Content = content;
		}

		/// <summary>
		/// Gets the text content of the message
		/// </summary>
		public string Content { get; }

		internal override MessageContentType ContentType => MessageContentType.Text;

		internal override MessageContent AsClientContent() => new MessageContent { Text = Content };
	}
}
