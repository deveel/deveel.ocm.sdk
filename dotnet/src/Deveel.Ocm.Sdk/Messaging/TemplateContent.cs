using System;

using Deveel.Messaging.Models;

namespace Deveel.Messaging {
	/// <summary>
	/// The reference to a message template that is configured in the
	/// remote service
	/// </summary>
	public sealed class TemplateContent : MessageContentBase {
		/// <summary>
		/// Constructs the template reference specifying its remote unique identifier
		/// </summary>
		/// <param name="id">The unique identifier of the template</param>
		/// <exception cref="ArgumentException">
		/// Thrown if the specified unique identifier is <c>null</c> or an empty string.
		/// </exception>
		public TemplateContent(string id) {
			if (string.IsNullOrWhiteSpace(id)) 
				throw new ArgumentException($"'{nameof(id)}' cannot be null or whitespace.", nameof(id));

			Id = id;
		}

		/// <summary>
		/// Gets the unique identifier of the template
		/// </summary>
		public string Id { get; }

		internal override MessageContentType ContentType => MessageContentType.Template;

		/// <summary>
		/// Gets or sets a the merge values to be used by the service to form
		/// the single message.
		/// </summary>
		public IDictionary<string, object?>? MergeValues { get; set; }

		internal override MessageContent AsClientContent()
			=> throw new NotSupportedException("Templates not supported yet!");
	}
}
