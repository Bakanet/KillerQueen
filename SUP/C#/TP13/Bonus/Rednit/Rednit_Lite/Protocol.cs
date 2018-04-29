using System;

namespace Rednit_Lite
{
    /// <summary>
    ///   The enum that defines a type of request.
    ///   Error: sent by the server. The request sent by the user contained an error.
    ///   Response: sent by the server. The request sent by the user completed successfully.
    ///   Connect: sent by the clients. Request to connect to an account.
    ///   Create: sent by the clients. Request to create an account.
    ///   RequestData: sent by the clients. Request the profile of a client.
    ///   SendData: sent by the clients. Update the client's profile.
    ///   RequestMatch: sent by the clients. Ask a new profile to Like or Dislike.
    ///   Like: sent by the clients. Tell the server the client liked a certain profile.
    ///   Dislike: sent by the clients. Tell the server the client disliked a certain profile.
    ///   RequestFriends: sent by the clients. Request the list of friends.
    ///   MessageTo: sent by the clients. Send message to a user.
    ///   MessageFrom: sent by the clients. Receive message from a user.
    /// </summary>
    public enum MessageType
	{
		Error,
		Response,
		Connect,
		Create,
		RequestData,
		SendData,
		RequestMatch,
		Like,
		Dislike,
		RequestFriends,
		MessageTo,
		MessageFrom
	}

    /// <summary>
    ///   The application protocol.
    /// </summary>
    [Serializable]
	public class Protocol
	{
		#region Constructor

		public Protocol(MessageType type)
		{
			Type = type;
			Message = string.Empty;
			Login = string.Empty;
			Password = string.Empty;
			User = new UserData();
		}

		#endregion

		#region Getter/Setter

		public MessageType Type { get; }
		public string Message { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public UserData User { get; set; }

		#endregion
	}
}