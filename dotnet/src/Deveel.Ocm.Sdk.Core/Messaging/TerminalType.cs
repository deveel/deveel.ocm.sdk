using System;

namespace Deveel.Messaging {
	/// <summary>
	/// Enumerates the possible types of terminals that are
	/// used within the OCM platform to send or receive messages
	/// </summary>
	public enum TerminalType {
		/// <summary>
		/// Represents a RFC-5322 e-mail address
		/// </summary>
		EmailAddress = 1,

		/// <summary>
		/// Represents a numeric phone number, that can be
		/// in the international or national format (depending
		/// on the context of usage)
		/// </summary>
		PhoneNumber = 2,

		/// <summary>
		/// Identifies a user of a messaging platform
		/// </summary>
		User = 3,

		/// <summary>
		/// Identifies a conversation between one or more
		/// participants
		/// </summary>
		Conversation = 4,

		/// <summary>
		/// An alpha-numeric label that is used to send 
		/// broadcasted messages
		/// </summary>
		AlphaNumeric = 5
	}
}
