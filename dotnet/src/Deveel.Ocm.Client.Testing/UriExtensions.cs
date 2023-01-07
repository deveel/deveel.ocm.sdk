using System;
using System.Globalization;
using System.Web;

namespace Deveel {
	public static class UriExtensions {
		public static string? GetQueryValue(this Uri uri, string key) {
			if (String.IsNullOrWhiteSpace(uri.Query)) 
				return null;

			if (string.IsNullOrWhiteSpace(key))
				throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));

			var query = HttpUtility.ParseQueryString(uri.Query);
			return query[key];
		}

		public static T? GetQueryValue<T>(this Uri uri, string key) {
			var stringValue = uri.GetQueryValue(key);
			if (String.IsNullOrWhiteSpace(stringValue))
				return default(T);

			return (T) Convert.ChangeType(stringValue, typeof(T), CultureInfo.InvariantCulture);
		}
	}
}
