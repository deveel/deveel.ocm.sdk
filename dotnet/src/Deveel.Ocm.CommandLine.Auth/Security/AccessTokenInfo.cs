using System;

namespace Deveel.Security {
	class AccessTokenInfo {
		public string TenantId { get; set; }

		public string UserId { get; set; }

		public string AccessToken { get; set; }

		public string RefreshToken { get; set; }

		public DateTimeOffset ExpiresOn { get; set; }
	}
}
