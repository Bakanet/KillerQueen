using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Rednit_Lite
{
	public static class Network
	{
		/// <summary>
		///   Create a TcpClient to connect to the server.
		///   The server's connection data is in class Data.
		///   You do not have to throw or catch any exception.
		/// </summary>
		/// <returns> Returns the new TcpClient connected to the server.</returns>
		public static TcpClient ConnectSocket()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///   Receive a message from the server.
		///   You have to understand this function.
		///   Although it is not optimal, it is still a good way of receiving a message.
		///   Here is how it works:
		///   While there is no data to receive and the connection is still up, wait.
		///   If the connection is down, throw exception.
		///   It there is data to receive, keep going.
		///   Read byte by byte until there is nothing left and store it into an array.
		///   Use the given formatter to convert this byte array to a Protocol object.
		/// </summary>
		/// <returns>The received response Protocol object.</returns>
		private static Protocol ReceiveMessage()
		{
			while (Data.Client.Connected && Data.Client.Available <= 1)
			{
			}

			if (!Data.Client.Connected)
				throw new Exception("Disconnected from server.");
			var message = new List<byte>();
			var stream = Data.Client.GetStream();

#pragma warning disable CS0652
			while (stream.DataAvailable)
				message.Add((byte) stream.ReadByte());
#pragma warning restore CS0652

			var msg = Formatter.FromByteArray<Protocol>(message.ToArray());
			return msg;
		}

		/// <summary>
		///   Ask the server to create a new account with the given credentials: login and password.
		///   Create a new protocol object with the correct data.
		///   The type should be Create.
		///   The login should be put in the Login field.
		///   The password should be put in the Password field.
		///   Use the given Formatter class to transform this object to a byte array.
		///   Use the Send() function of the socket (Data.Client.Client) to send it.
		///   Wait for the server response with the given function above: ReceiveMessage().
		///   Set the correct return value: true if the type is Response else false.
		/// </summary>
		/// <param name="login">The login of the user.</param>
		/// <param name="password">The password of the user.</param>
		/// <returns>Returns whether the response of the server is an error or not.</returns>
		public static bool CreateAccount(string login, string password)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///   Ask the server to connect to an account with the given credentials: login and password.
		///   Create a new protocol object with the correct data.
		///   The type should be Connect.
		///   The login should be put in the Login field.
		///   The password should be put in the Password field.
		///   Use the given Formatter class to transform this object to a byte array.
		///   Use the Send() function of the socket (Data.Client.Client) to send it.
		///   Wait for the server response with the given function above: ReceiveMessage().
		///   Set the correct return value: true if the type is Response else false.
		/// </summary>
		/// <param name="login">The login of the user.</param>
		/// <param name="password">The password of the user.</param>
		/// <returns>Returns whether the response of the server is an error or not.</returns>
		public static bool ConnectAccount(string login, string password)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///   Ask the server the data of a certain user.
		///   Create a new protocol object with the correct data.
		///   The type should be RequestData.
		///   The login should be put in the Login field.
		///   Use the given Formatter class to transform this object to a byte array.
		///   Use the Send() function of the socket (Data.Client.Client) to send it.
		///   Wait for the server response with the given function above: ReceiveMessage().
		///   Set the correct return value: the UserData object returned by the server or null if an error occured.
		/// </summary>
		/// <param name="login">The login of the user.</param>
		/// <returns>Returns the UserData object returned by the server or null.</returns>
		public static UserData AskData(string login)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///   Send to the server the data of a certain user.
		///   Create a new protocol object with the correct data.
		///   The type should be SendData.
		///   The user should be put in the User field.
		///   Use the given Formatter class to transform this object to a byte array.
		///   Use the Send() function of the socket (Data.Client.Client) to send it.
		///   Wait for the server response with the given function above: ReceiveMessage().
		///   Set the correct return value: true if the type is Response else false.
		/// </summary>
		/// <param name="user">The user to send.</param>
		/// <returns>Returns whether the response of the server is an error or not.</returns>
		public static bool SendData(UserData user)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///   Send to the server that you liked a user.
		///   Create a new protocol object with the correct data.
		///   The type should be Like or Dislike.
		///   Your login should be put in the login field.
		///   The liked login should be put in the message field.
		///   Use the given Formatter class to transform this object to a byte array.
		///   Use the Send() function of the socket (Data.Client.Client) to send it.
		///   Wait for the server response with the given function above: ReceiveMessage().
		///   Set the correct return value: true if the type is Response else false.
		/// </summary>
		/// <param name="login">The login of the liked or dislike user.</param>
		/// <param name="like">Wether it is like or dislike. True for Like.</param>
		/// <returns>Returns whether the response of the server is an error or not.</returns>
		public static bool SendLike(string login, bool like)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///   Ask the server a user the client might like.
		///   Create a new protocol object with the correct data.
		///   The type should be RequestMatch.
		///   The login should be put in the Login field.
		///   Use the given Formatter class to transform this object to a byte array.
		///   Use the Send() function of the socket (Data.Client.Client) to send it.
		///   Wait for the server response with the given function above: ReceiveMessage().
		///   Set the correct return value: the UserData object returned by the server or null if an error occured.
		/// </summary>
		/// <param name="login">The login of the user.</param>
		/// <returns>Returns the UserData object returned by the server or null.</returns>
		public static UserData AskMatch(string login)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///   Hack the password of an account.
		///   Try all possible passwords until the right one is found.
		///   Use a HackerTools object, it will generate one password after another.
		///   If the password is too long (> 4 characters or has special charaters) you can just kill your program
		///   as it will run indefinitely.
		/// </summary>
		/// <param name="login">The login of the account to hack.</param>
		/// <returns>The found password.</returns>
		public static string HackBruteForce(string login)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///   Hack the password of an account.
		///   Brute forcing is not a good idea for slightly longer passwords.
		///   You have to get the password in another way.
		///   This passwork leak has been added intentionaly and is quite obvious.
		///   It will just test if you have understood what you are doing.
		///   You might want to use the debugger and try multiple possibilities.
		///   The function should not exceed 15 lines.
		/// </summary>
		/// <param name="login">The login of the account to hack.</param>
		/// <returns>The found password.</returns>
		public static string HackIntelligent(string login)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///   Ask your list of friends to the server.
		///   Create a new protocol object with the correct data.
		///   The type should be RequestFriends.
		///   The login should be put in the Login field.
		///   Use the given Formatter class to transform this object to a byte array.
		///   Use the Send() function of the socket (Data.Client.Client) to send it.
		///   Wait for the server response with the given function above: ReceiveMessage().
		///   The return value should be an array of logins (string) if the server returned a Response else null.
		///   If everything goes well, the friend list is given in th Message field with the following format:
		///   "'login1' 'login2' 'login3'". You have to make a string per login and strip the simple quotes.
		/// </summary>
		/// <returns></returns>
		public static string[] AskFriends()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///   Send a message to another user.
		///   Create a new protocol object with the correct data.
		///   The type should be MessageTo.
		///   The login should be the target user.
		///   Use the given Formatter class to transform this object to a byte array.
		///   Use the Send() function of the socket (Data.Client.Client) to send it.
		///   Wait for the server response with the given function above: ReceiveMessage().
		///   Set the correct return value: true if the type is Response else false.
		/// </summary>
		/// <param name="login"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public static bool MessageTo(string login, string message)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///   Receive a message from another user.
		///   Create a new protocol object with the correct data.
		///   The type should be MessageFrom.
		///   The login should be the target user.
		///   Use the given Formatter class to transform this object to a byte array.
		///   Use the Send() function of the socket (Data.Client.Client) to send it.
		///   Wait for the server response with the given function above: ReceiveMessage().
		///   Set the correct return value: the string in message field returned by the server or null if an error occured.
		/// </summary>
		/// <param name="login"></param>
		/// <returns></returns>
		public static string MessageFrom(string login)
		{
			throw new NotImplementedException();
		}
	}
}