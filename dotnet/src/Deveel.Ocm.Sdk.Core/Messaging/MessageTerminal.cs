using System;

namespace Deveel.Messaging {
	/// <summary>
	/// Describes a terminal that is used by the platform to
	/// route messages from and to
	/// </summary>
	public struct MessageTerminal {
		/// <summary>
		/// Constructs a new messaging terminal
		/// </summary>
		/// <param name="type">The type of terminal</param>
		/// <param name="endPoint">The address of the terminal, constraint to the specific
		/// format of the type (<strong>note</strong>: this might be even not a network
		/// address, such in the case of <c>user</c>, <c>conversation</c>, etc.)</param>
		/// <exception cref="ArgumentException">
		/// Thrown if the end-point address specified is <c>null</c> or an empty string.
		/// </exception>
		public MessageTerminal(TerminalType type, string endPoint) {
			if (string.IsNullOrWhiteSpace(endPoint))
				throw new ArgumentException($"'{nameof(endPoint)}' cannot be null or whitespace.", nameof(endPoint));

			// TODO: validate the end-point accordingly to the type...

			Type = type;
			EndPoint = endPoint;
		}

		/// <summary>
		/// Gets the type of the terminal
		/// </summary>
		public TerminalType Type { get; }

		/// <summary>
		/// Gets the end-point of the terminal
		/// </summary>
		public string EndPoint { get; }

		// TODO: Validate the format for fast-fail on the client-side
		public static MessageTerminal Email(string address)
			=> new MessageTerminal(TerminalType.EmailAddress, address);

		// TODO: Validate the format for fast-fail on the client-side
		public static MessageTerminal Phone(string number)
			=> new MessageTerminal(TerminalType.PhoneNumber, number);

		public static MessageTerminal User(string userId)
			=> new MessageTerminal(TerminalType.User, userId);

		public static MessageTerminal Conversation(string conversationId)
			=> new MessageTerminal(TerminalType.Conversation, conversationId);
	}
}
