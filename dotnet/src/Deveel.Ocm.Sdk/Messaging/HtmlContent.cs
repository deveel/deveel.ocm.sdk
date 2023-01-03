using System;

using Deveel.Messaging.Models;

namespace Deveel.Messaging {
	internal class HtmlContent : MessageContentBase {
		internal override MessageContentType ContentType => MessageContentType.Html;

		public HtmlContent(string content) {
			if (string.IsNullOrWhiteSpace(content)) 
				throw new ArgumentException($"'{nameof(content)}' cannot be null or whitespace.", nameof(content));

			Content = content;
		}

		public string Content { get; }

		public IList<MessageAttachment>? Attachments { get; set; }

		internal override MessageContent AsClientContent() {
			return new MessageContent {
				Html = Content,
				Attachments = Attachments?.Select(x => x.AsClientAttachment()).ToList()
			};
		}
	}
}
