using System;
using System.Diagnostics.CodeAnalysis;

using Deveel.Messaging.Models;

namespace Deveel.Messaging {
	/// <summary>
	/// Describes a single outbound message from an application
	/// to a single receiver.
	/// </summary>
	public sealed class Message : MessageBase {
		/// <summary>
		/// Constructs a new message
		/// </summary>
		/// <param name="channelName"></param>
		/// <param name="sender"></param>
		/// <param name="receiver"></param>
		/// <param name="content"></param>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="ArgumentNullException"></exception>
		public Message(ChannelName channelName, MessageTerminal sender, MessageTerminal receiver, MessageContentBase content)
			: base(channelName, sender, receiver, content) {
		}

		public Message(ChannelName channelName, MessageTerminal receiver, MessageContentBase content)
			: base(channelName, null, receiver, content) {
		}


		/// <summary>
		/// Gets or sets a context attached to the message
		/// </summary>
		public IDictionary<string, object?>? Context { get; set; }


		public void SetContext(IDictionary<string, object?> context) {
			if (context != null) {
				if (Context == null) {
					Context = new Dictionary<string, object?>(context);
				} else {
					foreach (var item in context) {
						Context[item.Key] = item.Value;
					}
				}
			}
		}

		public void SetContext(string key, object? value) {
			if (string.IsNullOrWhiteSpace(key))
				throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));

			if (Context == null)
				Context = new Dictionary<string, object?>();

			Context[key] = value;
		}

		internal Models.Message AsClientMessage() {
			var message = new Models.Message(AsClientTerminal(Receiver), Content.AsClientContent(), ChannelName) {
				Sender = AsClientSenderTerminal(Sender),
				Options = Options,
				Context = Context
			};

			if (Extensions != null) {
				// TODO: set the AdditionalProperties
			}

			if (Fallback != null)
				message.Fallback = Fallback.AsClientMessage();

			return message;
		}
	}
}
