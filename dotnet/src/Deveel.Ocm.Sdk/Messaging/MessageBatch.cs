using System;
using System.Collections;

namespace Deveel.Messaging {
	public sealed class MessageBatch : IEnumerable<Message> {
		// TODO: make this number configurable...
		private const int MaxSize = 100;
		private readonly List<Message> messages = new List<Message>();

		public IReadOnlyList<Message> Messages => messages.AsReadOnly();

		public int Size => messages.Count;

		public IDictionary<string, object?>? Context { get; set; }

		public MessageBatch Add(Message message) {
			if (message is null) 
				throw new ArgumentNullException(nameof(message));

			if (messages.Count > MaxSize)
				throw new ArgumentException("The maximum size of the batch was exceeded");

			messages.Add(message);

			return this;
		}

		public MessageBatch AddRange(IEnumerable<Message> messages) {
			if (messages is null) 
				throw new ArgumentNullException(nameof(messages));

			foreach (var message in messages) {
				Add(message);
			}

			return this;
		}

		public IEnumerator<Message> GetEnumerator() => messages.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		internal Models.MessageBatch AsClientBatch() {
			return new Models.MessageBatch(messages.Select(x => x.AsClientMessage())) {
				Context = Context?.ToDictionary(x => x.Key, y => y.Value)
			};
		}
	}
}
