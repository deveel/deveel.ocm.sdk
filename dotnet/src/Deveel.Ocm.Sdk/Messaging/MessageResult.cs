using System;

using Deveel.Messaging.Models;

namespace Deveel.Messaging {
	public sealed class MessageResult {
		private readonly Models.MessageResult result;

		internal MessageResult(Models.MessageResult result) {
			this.result = result;
		}

		public string MessageId => result.MessageId;

		public IReadOnlyDictionary<string, object?>? Context => result.Context;
	}
}
