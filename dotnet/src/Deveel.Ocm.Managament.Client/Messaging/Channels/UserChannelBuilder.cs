using System;

using Deveel.Messaging.Terminals;

namespace Deveel.Messaging.Channels {
	public sealed class UserChannelBuilder {
		private ChannelName? channelName;
		private ChannelType? channelType;
		private ChannelProvider? channelProvider;
		private ChannelDirections? channelDirections;
		private IDictionary<string, object>? channelContext;
		private IList<MessageContentType>? channelContentTypes;
		private IDictionary<string, object>? channelSettings;

		public UserChannelBuilder() {
		}

		public UserChannelBuilder WithName(ChannelName name) {
			channelName = name;
			return this;
		}

		public UserChannelBuilder WithName(string name)
			=> WithName(new ChannelName(name));

		public UserChannelBuilder OfType(ChannelType type) {
			channelType = type;
			return this;
		}

		public UserChannelBuilder ProvidedBy(ChannelProvider provider) {
			channelProvider = provider;
			return this;
		}

		public UserChannelBuilder ProvidedBy(string provider)
			=> ProvidedBy(new ChannelProvider(provider));

		public UserChannelBuilder WithContext(IDictionary<string, object> context) {
			channelContext = context ?? throw new ArgumentNullException(nameof(context));

			return this;
		}

		public UserChannelBuilder WithContext(string key, object? value) {
			if (string.IsNullOrWhiteSpace(key))
				throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));

			// TODO: validate the setting value is of the accepted types

			if (channelContext == null)
				channelContext = new Dictionary<string, object>();

			if (value == null) {
				channelContext.Remove(key);
			} else {
				channelContext[key] = value;
			}

			return this;
		}

		public UserChannelBuilder With(IDictionary<string, object> settings) {
			// TODO: validate the setting value is of the accepted types

			channelSettings = settings ?? throw new ArgumentNullException(nameof(settings));

			return this;
		}

		public UserChannelBuilder With(string key, object? value) {
			if (channelSettings == null)
				channelSettings = new Dictionary<string, object>();

			if (value == null) {
				channelSettings.Remove(key);
			} else {
				channelSettings[key] = value;
			}

			return this;
		}

		public UserChannelBuilder WithDirection(ChannelDirections directions) {
			if (channelDirections != null) {
				channelDirections |= directions;
			} else {
				channelDirections = directions;
			}

			return this;
		}

		public UserChannelBuilder AsOutbound() => WithDirection(ChannelDirections.Outbound);

		public UserChannelBuilder AsInbound() => WithDirection(ChannelDirections.Inbound);

		public UserChannelBuilder AsDuplex() => WithDirection(ChannelDirections.Duplex);

		public UserChannelBuilder Handling(params MessageContentType[] contentTypes) {
			if (channelContentTypes == null)
				channelContentTypes = new List<MessageContentType>();

			foreach (var contentType in contentTypes) {
				if (!channelContentTypes.Contains(contentType))
					channelContentTypes.Add(contentType);
			}

			return this;
		}

		public UserChannelBuilder HandlingText() => Handling(MessageContentType.Text);

		public UserChannelBuilder HandlingHtml() => Handling(MessageContentType.Html);

		public UserChannelBuilder HandlingTemplates() => Handling(MessageContentType.Template);

		public UserChannel Build() {
			if (channelName == null)
				throw new FormatException("The channel name was not set");
			if (channelType == null)
				throw new FormatException("The channel type was not set");
			if (channelProvider == null)
				throw new FormatException("The channel provider was not specified");

			var channel = new UserChannel(channelName.Value, channelType.Value, channelProvider.Value);

			if (channelDirections != null)
				channel.Directions = channelDirections.Value;

			if (channelContentTypes != null)
				channel.ContentTypes = channelContentTypes.ToList();
			
			if (channelContext != null) {
				channel.Context = channelContext.ToDictionary(x => x.Key, y => y.Value);
			}

			if (channelSettings != null) {
				channel.Settings = channelSettings.ToDictionary(x => x.Key, y => y.Value);
			}

			return channel;
		}
	}
}
