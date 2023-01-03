using System;

namespace Deveel.Messaging {
	/// <summary>
	/// the types of attachment to a message
	/// </summary>
	public enum AttachmentType {
		/// <summary>
		/// The attachment is inline in the message
		/// </summary>
		Inline = 1,

		/// <summary>
		/// The attachment is a file appended to the message
		/// </summary>
		File = 2,
	}
}
