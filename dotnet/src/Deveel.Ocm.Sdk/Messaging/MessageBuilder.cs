using System;

namespace Deveel.Messaging {
	public sealed class MessageBuilder {
		private string? channelName;
		private MessageTerminal? sender;
		private MessageTerminal? receiver;
		private IDictionary<string, object?>? extensions;
		private IDictionary<string, object?>? options;
		private IDictionary<string, object?>? context;
		private MessageContentBase? content;
		private FallbackMessage? fallback;

		public MessageBuilder UseChannel(string name) {
			if (string.IsNullOrWhiteSpace(name)) 
				throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));

			this.channelName = name;
			return this;
		}

		public MessageBuilder From(MessageTerminal sender) {
			this.sender = sender;
			return this;
		}

		public MessageBuilder FromEmail(string address)
			=> From(MessageTerminal.Email(address));

		public MessageBuilder FromPhone(string number)
			=> From(MessageTerminal.Phone(number));

		public MessageBuilder FromUser(string userId)
			=> From(MessageTerminal.User(userId));

		public MessageBuilder To(MessageTerminal receiver) {
			this.receiver = receiver;
			return this;
		}

		public MessageBuilder ToEmail(string address)
			=> To(MessageTerminal.Email(address));

		public MessageBuilder ToPhone(string number)
			=> To(MessageTerminal.Phone(number));

		public MessageBuilder ToUser(string userId)
			=> To(MessageTerminal.User(userId));

		public MessageBuilder ToConversation(string conversationId)
			=> To(MessageTerminal.Conversation(conversationId));

		public MessageBuilder With(string name, object? value) {
			if (string.IsNullOrWhiteSpace(name)) 
				throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));

			if (extensions == null)
				extensions = new Dictionary<string, object?>();

			extensions[name] = value;

			return this;
		}

		public MessageBuilder WithOption(string name, object? value) {
			if (string.IsNullOrWhiteSpace(name)) 
				throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));

			if (options == null)
				options = new Dictionary<string, object?>();

			options[name] = value;

			return this;
		}

		public MessageBuilder WithContext(string name, object? value) {
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));

			if (context == null)
				context = new Dictionary<string, object?>();

			context[name] = value;

			return this;
		}

		public MessageBuilder HasContent(MessageContentBase content) {
			this.content = content ?? throw new ArgumentNullException(nameof(content));

			return this;
		}

		public MessageBuilder HasTemplateContent(Action<TemplateContentBuilder> configure) {
			var builder = new TemplateContentBuilder();
			configure(builder);

			return HasContent(builder.Build());
		}

		public MessageBuilder HasHtmlContent(Action<HtmlContentBuilder> configure) {
			var builder = new HtmlContentBuilder();
			configure(builder);

			return HasContent(builder.Build());
		}

		public MessageBuilder HasTextContent(Action<TextContentBuilder> configure) {
			var builder = new TextContentBuilder();
			configure(builder);
			return HasContent(builder.Build());
		}

		public MessageBuilder HasTextContent(string text)
			=> HasTextContent(builder => builder.Append(text));

		public MessageBuilder FallbackTo(Action<FallbackMessageBuilder> configure) {
			var builder = new FallbackMessageBuilder();
			configure(builder);

			fallback = builder.Build();

			return this;
		}

		public Message Build() {
			if (receiver == null)
				throw new InvalidOperationException("The receiver of the message is missing");
			if (content == null)
				throw new InvalidOperationException("The content of the message is missing");

			if (String.IsNullOrWhiteSpace(channelName))
				throw new InvalidOperationException("The channel was not specified");

			Message message;

			if (sender != null) {
				message = new Message(channelName, sender.Value, receiver.Value, content);
			} else {
				message = new Message(channelName, receiver.Value, content);
			}

			if (extensions != null)
				message.SetExtensions(extensions);
			if (context != null)
				message.SetContext(context);
			if (options != null)
				message.SetOptions(options);

			message.Fallback = fallback;

			return message;
		}
	}
}
