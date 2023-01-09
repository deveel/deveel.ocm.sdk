using System;

namespace Deveel.Messaging {
	public sealed class TemplateContentBuilder {
		internal TemplateContentBuilder() {
		}

		private string? id;
		private IDictionary<string, object?>? mergeValues;

		public TemplateContentBuilder HasId(string templateId) {
			if (string.IsNullOrWhiteSpace(templateId)) 
				throw new ArgumentException($"'{nameof(templateId)}' cannot be null or whitespace.", nameof(templateId));

			id = templateId;

			return this;
		}

		public TemplateContentBuilder With(string key, object? value) {
			if (string.IsNullOrWhiteSpace(key)) 
				throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));

			if (mergeValues == null)
				mergeValues = new Dictionary<string, object?>();

			mergeValues[key] = value;

			return this;
		}

		public TemplateContentBuilder With(IDictionary<string, object?> values) {
			if (values == null) {
				mergeValues = null;
			} else {
				if (mergeValues == null) {
					mergeValues = new Dictionary<string, object?>(values);
				} else {
					foreach (var item in values) {
						mergeValues[item.Key] = item.Value;
					}
				}
			}

			return this;
		}

		internal TemplateContent Build() {
			if (String.IsNullOrWhiteSpace(id))
				throw new InvalidOperationException("The template identifier was not specified");

			return new TemplateContent(id) { MergeValues = mergeValues };
		}
	}
}
