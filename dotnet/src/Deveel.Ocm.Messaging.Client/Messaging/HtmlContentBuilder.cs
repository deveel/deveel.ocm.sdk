using System;
using System.Text;

namespace Deveel.Messaging {
	public sealed class HtmlContentBuilder {
		internal HtmlContentBuilder() {
		}

		private StringBuilder? content;
		private IList<MessageAttachment>? attachments;

		public HtmlContentBuilder Append(string html) {
			if (content == null)
				content = new StringBuilder();

			content.Append(html);

			return this;
		}

		public HtmlContentBuilder Attach(MessageAttachment attachment) {
			if (attachments == null)
				attachments = new List<MessageAttachment>();

			attachments.Add(attachment);

			return this;
		}

		public HtmlContentBuilder Attach(string id, BinaryData data) {
			if (string.IsNullOrWhiteSpace(id)) 
				throw new ArgumentException($"'{nameof(id)}' cannot be null or whitespace.", nameof(id));
			if (data is null) 
				throw new ArgumentNullException(nameof(data));

			return Attach(new MessageAttachment(id, data));
		}

		internal HtmlContent Build() {
			if (content == null || content.Length == 0)
				throw new InvalidOperationException("the content of the message was not set");
			
			var htmlContent = new HtmlContent(content.ToString());

			if (attachments != null) {
				htmlContent.Attachments = new List<MessageAttachment>(attachments);
			}

			return htmlContent;
		}
	}
}
