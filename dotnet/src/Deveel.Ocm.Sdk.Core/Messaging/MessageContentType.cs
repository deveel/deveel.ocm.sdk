using System;

namespace Deveel.Messaging {
	/// <summary>
	/// Enumerates the types of message contents supported
	/// by the OCM platform.
	/// </summary>
	public enum MessageContentType {
		/// <summary>
		/// The content of the message is a plain-text content 
		/// </summary>
		Text = 1,

		/// <summary>
		/// The content of the message is an Hyper-Textual Markup Language (HTML)
		/// textual content
		/// </summary>
		Html = 2,

		/// <summary>
		/// The content of the message is a reference to a remote
		/// template that is formatted with the merge information passed
		/// </summary>
		Template = 3,

		// TODO: other formats to be supported
	}
}
