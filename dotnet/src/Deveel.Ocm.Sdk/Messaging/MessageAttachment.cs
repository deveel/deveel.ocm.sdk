using System;

namespace Deveel.Messaging {
	public sealed class MessageAttachment {
		public MessageAttachment(string id, BinaryData content) {
			if (string.IsNullOrWhiteSpace(id))
				throw new ArgumentException($"'{nameof(id)}' cannot be null or whitespace.", nameof(id));

			Id = id;
			Content = content ?? throw new ArgumentNullException(nameof(content));
		}

		public AttachmentType Type { get; }

		public string Id { get; }

		public BinaryData Content { get; }

		public string? FileName { get; set; }

		public string? ContentType { get; set; }

		internal Models.Attachment AsClientAttachment() {
			return new Models.Attachment(Id, AsBase64Content()) {
				ContentType = ContentType,
				FileName = FileName,
				Type = AsClientAttachmentType()
			};
		}

		private Models.AttachmentType? AsClientAttachmentType()
			=> Type switch {
				AttachmentType.Inline => Models.AttachmentType.Inline,
				AttachmentType.File => Models.AttachmentType.File,
				_ => throw new NotSupportedException("Attachment type not supported")
			};

		private string AsBase64Content() {
			// TODO: is there a more optimized way for this?
			var bytes = Content.ToArray();
			return Convert.ToBase64String(bytes);
		}
	}
}
