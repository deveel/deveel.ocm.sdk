using System;

namespace Deveel.Messaging.Channels {
	static class MessageContentTypeExtensions {
		public static Management.Models.MessageContentType AsClientMessageContentType(this MessageContentType contentType)
			=> contentType switch {
				MessageContentType.Text => Management.Models.MessageContentType.Text,
				MessageContentType.Html => Management.Models.MessageContentType.Html,
				MessageContentType.Template => Management.Models.MessageContentType.Template,
				_ => throw new NotSupportedException($"The content type '{contentType}' is not supported")
			};

		public static MessageContentType AsMessageContentType(this Management.Models.MessageContentType contentType)
			=> contentType.ToString() switch {
				var x when contentType.ToString() == Management.Models.MessageContentType.Html => MessageContentType.Html,
				var x when contentType.ToString() == Management.Models.MessageContentType.Text => MessageContentType.Text,
				var x when contentType.ToString() == Management.Models.MessageContentType.Template => MessageContentType.Template,
				_ => throw new NotSupportedException($"The content type '{contentType}' is not supported")
			};
	}
}
