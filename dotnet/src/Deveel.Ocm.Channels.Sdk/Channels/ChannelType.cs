using System;

namespace Deveel.Messaging.Channels {
	/// <summary>
	/// Enumerates the types of messaging channels available 
	/// within the OCM platform
	/// </summary>
	public enum ChannelType {
		/// <summary>
		/// An e-mail message transportation channel
		/// </summary>
		Email = 1,

		/// <summary>
		/// A Short Message Service (SMS) messaging channel
		/// </summary>
		Sms = 2,

		/// <summary>
		/// The Facebook Messenger channel
		/// </summary>
		Facebook = 3,

		/// <summary>
		/// An instance of the Telegram messaging platform
		/// </summary>
		Telegram = 4,

		/// <summary>
		/// An instance of the WhatsApp channel
		/// </summary>
		WhatsApp = 5,

		Push = 6

		// TODO: support for more channels
	}
}
