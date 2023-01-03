using System;

using Deveel.Messaging.Models;

namespace Deveel.Messaging {
	public abstract class MessageBase {
		protected MessageBase(string channelName, MessageTerminal? sender, MessageTerminal receiver, MessageContentBase content) {
			if (string.IsNullOrWhiteSpace(channelName))
				throw new ArgumentException($"'{nameof(channelName)}' cannot be null or whitespace.", nameof(channelName));

			ChannelName = channelName;
			Sender = sender;
			Receiver = receiver;
			Content = content ?? throw new ArgumentNullException(nameof(content));
		}


		/// <summary>
		/// Gets the name of the channel used to transport the message
		/// from an application to the receiver.
		/// </summary>
		public string ChannelName { get; }

		/// <summary>
		/// Gets the terminal address of the sender.
		/// </summary>
		/// <remarks>
		/// When this address is not specified, the service uses the default 
		/// terminal configured within the channel
		/// </remarks>
		public MessageTerminal? Sender { get; set; }

		/// <summary>
		/// Gets the terminal that is receiving the message
		/// </summary>
		public MessageTerminal Receiver { get; }

		/// <summary>
		/// Gets the content of the message
		/// </summary>
		public MessageContentBase Content { get; }

		/// <summary>
		/// Gets or sets a message that is send if this fails to be
		/// sent or delivered at the configured conditions.
		/// </summary>
		public FallbackMessage? Fallback { get; set; }

		/// <summary>
		/// Gets or sets extensions to the required elements of the message.
		/// </summary>
		public IDictionary<string, object?>? Extensions { get; set; }

		/// <summary>
		/// Gets or sets options to control the behavior of the message handling
		/// by the service.
		/// </summary>
		public IDictionary<string, object?>? Options { get; set; }

		public void SetExtensions(IDictionary<string, object?> extensions) {
			if (extensions != null) {
				if (Extensions == null) {
					Extensions = new Dictionary<string, object?>(extensions);
				} else {
					foreach (var item in extensions) {
						Extensions[item.Key] = item.Value;
					}
				}
			}
		}

		public void SetExtension(string key, object? value) {
			if (string.IsNullOrWhiteSpace(key))
				throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));

			if (Extensions == null)
				Extensions = new Dictionary<string, object?>();

			Extensions[key] = value;
		}

		public void SetOptions(IDictionary<string, object?> options) {
			if (options != null) {
				if (Options == null) {
					Options = new Dictionary<string, object?>(options);
				} else {
					foreach (var item in options) {
						Options[item.Key] = item.Value;
					}
				}
			}
		}

		internal static Models.SenderTerminal? AsClientSenderTerminal(MessageTerminal? sender) {
			if (sender == null)
				return null;

			var terminal = sender.Value;

			return terminal.Type switch {
				TerminalType.PhoneNumber => new SenderTerminal { Number = terminal.EndPoint },
				TerminalType.EmailAddress => new SenderTerminal { EmailAddress = terminal.EndPoint },
				TerminalType.User => new SenderTerminal { User = terminal.EndPoint },
				TerminalType.Conversation => new SenderTerminal { Conversation = terminal.EndPoint },
				TerminalType.AlphaNumeric => new SenderTerminal { Label = terminal.EndPoint },
				_ => throw new NotSupportedException($"The type of terminal '{terminal.Type}' is not supported in this context")
			};
		}

		internal static Models.Terminal AsClientTerminal(MessageTerminal receiver) {
			return receiver.Type switch {
				TerminalType.PhoneNumber => new Terminal { Number = receiver.EndPoint },
				TerminalType.EmailAddress => new Terminal { EmailAddress = receiver.EndPoint },
				TerminalType.User => new Terminal { User = receiver.EndPoint },
				TerminalType.Conversation => new Terminal { Conversation = receiver.EndPoint },
				_ => throw new NotSupportedException($"The type of terminal '{receiver.Type}' is not supported in this context")
			};
		}
	}
}
