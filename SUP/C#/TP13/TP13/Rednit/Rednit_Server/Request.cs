using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Npgsql;

namespace Rednit_Server
{
    public static class Request
    {

        #region Requests
        /// <summary>
        /// Connect the client.
        /// </summary>
        /// <param name="msg">The message from the client.</param>
        /// <param name="clientData">The data about the client.</param>
        /// <returns>The response of the servers.</returns>
        /// <exception cref="Exception">In case something went bad. Returns an Error.</exception>
        public static Protocol Connection(Protocol msg, ClientData clientData)
        {
            NpgsqlCommand command = null;
            NpgsqlDataReader reader = null;
            try
            {
                if (!CheckLogin(msg.Login) || !CheckStr(msg.Password, 50))
                    throw new Exception("Bad login or password.");

                var strcmd = $"SELECT connect_('{Esc(msg.Login)}', '{Esc(msg.Password)}')";

                command = new NpgsqlCommand(strcmd, Data.DbConnection);
                reader = command.ExecuteReader(CommandBehavior.Default);
                reader.Read();
                var newlogin = (string)reader[0];

                CloseAll(reader, command);

                clientData.Login = string.IsNullOrEmpty(clientData.Login) ? newlogin : clientData.Login;

                return new Protocol(MessageType.Response) { Login = clientData.Login };
            }
            catch (Exception e)
            {
                CloseAll(reader, command);
                return new Protocol(MessageType.Error) { Message = e.Message };
            }
        }
        /// <summary>
        /// Create an account.
        /// </summary>
        /// <param name="msg">The message from the client.</param>
        /// <returns>The response of the servers.</returns>
        /// <exception cref="Exception">In case something went bad. Returns an Error.</exception>
        public static Protocol Creation(Protocol msg)
        {
            NpgsqlCommand command = null;
            try
            {
                if (!CheckLogin(msg.Login) || !CheckStr(msg.Password, 50))
                    throw new Exception("Bad login or password.");

                var strcmd = $"SELECT create_('{Esc(msg.Login)}', '{Esc(msg.Password)}')";

                command = new NpgsqlCommand(strcmd, Data.DbConnection);
                command.ExecuteNonQuery();

                CloseAll(null, command);

                return new Protocol(MessageType.Response);
            }
            catch (Exception e)
            {
                CloseAll(null, command);
                return new Protocol(MessageType.Error) { Message = e.Message };
            }
        }
        /// <summary>
        /// Get data from an account.
        /// </summary>
        /// <param name="msg">The message from the client.</param>
        /// <returns>The response of the servers.</returns>
        /// <exception cref="Exception">In case something went bad. Returns an Error.</exception>
        public static Protocol GetData(Protocol msg)
        {
            NpgsqlCommand command = null;
            NpgsqlDataReader reader = null;
            try
            {
                if (!CheckLogin(msg.Login))
                    throw new Exception("Bad login.");

                var strcmd = $"SELECT * FROM get_data_('{Esc(msg.Login)}')";
                command = new NpgsqlCommand(strcmd, Data.DbConnection);
                reader = command.ExecuteReader(CommandBehavior.SingleResult);
                
                reader.Read();
                var resp = ReadData(reader);
                
                CloseAll(reader, command);
                
                return resp;
            }
            catch (Exception e)
            {
                CloseAll(reader, command);
                return new Protocol(MessageType.Error) { Message = e.Message };
            }
        }
        /// <summary>
        /// Send data to an account.
        /// </summary>
        /// <param name="msg">The message from the client.</param>
        /// <returns>The response of the servers.</returns>
        /// <exception cref="Exception">In case something went bad. Returns an Error.</exception>
        public static Protocol SendData(Protocol msg)
        {
            NpgsqlCommand command = null;
            try
            {
                var data = msg.User;
                var picture = string.Empty;
                if (data.Picture != null)
                {
                    var filename = $"{data.Login}.png";
                    File.WriteAllBytes(filename, data.Picture);
                    picture = filename;
                }
                
                if (   !CheckLogin(data.Login)             || !CheckAge(data.Age)
                    || !CheckStr(data.Firstname, 50)       || !CheckStr(data.Lastname, 50)
                    || !CheckStr(data.Description, 1000)   || !CheckArr(data.Picture, 300000))
                    throw new Exception("Bad data sent.");


                var strcmd =
                    "UPDATE users " +
                    $"SET firstname='{Esc(data.Firstname)}', lastname='{Esc(data.Lastname)}', age={data.Age}," +
                    $"description='{Esc(data.Description)}', picture='{Esc(picture)}', " +
                    $"books={data.Books}, mangas_comics={data.MangasComics}, movies={data.Movies}," +
                    $"animes_series={data.AnimesSeries}, games={data.Games} "+
                    $"WHERE login='{Esc(data.Login)}'";
                
                command = new NpgsqlCommand(strcmd, Data.DbConnection);
                command.ExecuteNonQuery();

                CloseAll(null, command);

                return new Protocol(MessageType.Response);
            }
            catch (Exception e)
            {
                CloseAll(null, command);
                return new Protocol(MessageType.Error) { Message = e.Message };
            }
        }
        /// <summary>
        /// Ask the next user match.
        /// </summary>
        /// <param name="msg">The message from the client.</param>
        /// <returns>The response of the servers.</returns>
        /// <exception cref="Exception">In case something went bad. Returns an Error.</exception>       
        public static Protocol AskMatch(Protocol msg)
        {
            NpgsqlCommand command = null;
            NpgsqlDataReader reader = null;
            try
            {
                if (!CheckLogin(msg.Login))
                    throw new Exception("Bad login.");

                var strcmd = $"SELECT * FROM match_('{Esc(msg.Login)}')";
                command = new NpgsqlCommand(strcmd, Data.DbConnection);
                reader = command.ExecuteReader(CommandBehavior.SingleResult);
                
                reader.Read();
                var resp = ReadData(reader);
                
                CloseAll(reader, command);
                
                return resp;
            }
            catch (Exception e)
            {
                CloseAll(reader, command);
                return new Protocol(MessageType.Error) { Message = e.Message };
            }
        }
        /// <summary>
        /// Like a user, become friends.
        /// </summary>
        /// <param name="msg">The message from the client.</param>
        /// <param name="clientData">The data about the client.</param>
        /// <returns>The response of the servers.</returns>
        /// <exception cref="Exception">In case something went bad. Returns an Error.</exception>      
        public static Protocol ApplyLike(Protocol msg, ClientData clientData)
        {
            NpgsqlCommand command = null;
            try
            {
                if (!CheckLogin(msg.Login) || !CheckLogin(msg.Message) || msg.Login != clientData.Login)
                    throw new Exception("Bad login(s).");

                var strcmd = $"SELECT like_('{Esc(msg.Login)}', '{Esc(msg.Message)}')";
                command = new NpgsqlCommand(strcmd, Data.DbConnection);
                command.ExecuteNonQuery();

                CloseAll(null, command);
                
                return new Protocol(MessageType.Response);
            }
            catch (Exception e)
            {
                CloseAll(null, command);
                return new Protocol(MessageType.Error) { Message = e.Message };
            }
        }
        /// <summary>
        /// Dislike the user.
        /// </summary>
        /// <param name="msg">The message from the client.</param>
        /// <param name="clientData">The data about the client.</param>
        /// <returns>The response of the servers.</returns>
        /// <exception cref="Exception">In case something went bad. Returns an Error.</exception>      
        public static Protocol ApplyDislike(Protocol msg, ClientData clientData)
        {
            NpgsqlCommand command = null;
            try
            {
                if (!CheckLogin(msg.Login) || !CheckLogin(msg.Message) || msg.Login != clientData.Login)
                    throw new Exception("Bad login(s).");

                var strcmd = $"SELECT dislike_('{Esc(msg.Login)}', '{Esc(msg.Message)}')";
                command = new NpgsqlCommand(strcmd, Data.DbConnection);
                command.ExecuteNonQuery();

                CloseAll(null, command);
                
                return new Protocol(MessageType.Response);
            }
            catch (Exception e)
            {
                CloseAll(null, command);
                return new Protocol(MessageType.Error) { Message = e.Message };
            }
        }
        /// <summary>
        /// Get the list of your friends.
        /// </summary>
        /// <param name="msg">The message from the client.</param>
        /// <param name="clientData">The data about the client.</param>
        /// <returns>The response of the servers.</returns>
        /// <exception cref="Exception">In case something went bad. Returns an Error.</exception>      
        public static Protocol GetFriends(Protocol msg, ClientData clientData)
        {
            NpgsqlCommand command = null;
            NpgsqlDataReader reader = null;
            try
            {
                if (!CheckLogin(msg.Login) || msg.Login != clientData.Login)
                    throw new Exception("Bad login.");

                var strcmd = $"SELECT get_friends_('{Esc(msg.Login)}')";
                command = new NpgsqlCommand(strcmd, Data.DbConnection);
                reader = command.ExecuteReader();

                var list = new List<string>();
                
                while (reader.Read())
                    list.Add("'" + (string)reader[0] + "'");
                
                CloseAll(reader, command);
                string friends = string.Join(" ", list);

                return new Protocol(MessageType.Response)
                {
                    Login = clientData.Login,
                    Message = friends
                };
            }
            catch (Exception e)
            {
                CloseAll(reader, command);
                return new Protocol(MessageType.Error) { Message = e.Message };
            }            
        }
        /// <summary>
        /// Send a message to someone.
        /// </summary>
        /// <param name="msg">The message from the client.</param>
        /// <param name="clientData">The data about the client.</param>
        /// <returns>The response of the servers.</returns>
        /// <exception cref="Exception">In case something went bad. Returns an Error.</exception>
        public static Protocol MessageTo(Protocol msg, ClientData clientData)
        {
            try
            {
                if (!CheckLogin(msg.Login) || !CheckLogin(clientData.Login) || !CheckStr(msg.Message, 100000))
                    throw new Exception("Bad login or message too long.");

                if (string.IsNullOrEmpty(msg.Message))
                    return new Protocol(MessageType.Response);

                string file = msg.Login + clientData.Login + ".msg";
                File.AppendAllText(file, "\n" + msg.Message);
                CheckFile(file);
                
                return new Protocol(MessageType.Response);
            }
            catch (Exception e)
            {
                return new Protocol(MessageType.Error) { Message = e.Message };
            }
        }
        /// <summary>
        /// Receive a message from someone.
        /// </summary>
        /// <param name="msg">The message from the client.</param>
        /// <param name="clientData">The data about the client.</param>
        /// <returns>The response of the servers.</returns>
        /// <exception cref="Exception">In case something went bad. Returns an Error.</exception>
        public static Protocol MessageFrom(Protocol msg, ClientData clientData)
        {
            try
            {
                if (!CheckLogin(msg.Login) || !CheckLogin(clientData.Login))
                    throw new Exception("Bad login.");

                string file = clientData.Login + msg.Login + ".msg";
                if (!File.Exists(file))
                    return new Protocol(MessageType.Response);

                string text = File.ReadAllText(file);
                File.Delete(file);

                return new Protocol(MessageType.Response) { Message = text };
            }
            catch (Exception e)
            {
                return new Protocol(MessageType.Error) { Message = e.Message };
            }
        }
        #endregion

        #region Methods 
        /// <summary>
        /// Transforms the data from a database row to a protocol object.
        /// </summary>
        /// <param name="reader">The database row.</param>
        /// <returns>The protocol object.</returns>
        private static Protocol ReadData(IDataRecord reader)
        {
            byte[] picture;
            try
            {
                var filename = (string) reader[7];
                picture = File.ReadAllBytes(filename);
            }
            catch (Exception)
            {
                picture = null;
            }

            return new Protocol(MessageType.Response)
            {
                Login = (string) reader[1],
                Password = (string) reader[2],
                User = new UserData
                {
                    Login = (string) reader[1],
                    Firstname = (string) reader[3],
                    Lastname = (string) reader[4],
                    Age = (int) reader[5],
                    Description = (string) reader[6],
                    Picture = picture,
                    AnimesSeries = (bool) reader[8],
                    Books = (bool) reader[9],
                    Games = (bool) reader[10],
                    MangasComics = (bool) reader[11],
                    Movies = (bool) reader[12]

                }
            };
        } 
        /// <summary>
        /// Close Ngsql objects.
        /// </summary>
        /// <param name="reader">NpgsqlDataReader.</param>
        /// <param name="command">NpgsqlCommand.</param>
        private static void CloseAll(IDataReader reader, IDisposable command)
        {
            command?.Dispose();
            if (reader != null && !reader.IsClosed)
                reader.Close();
        }
        /// <summary>
        /// Prevent SQL injection. Remove for more fun.
        /// </summary>
        /// <param name="str">The string to transform.</param>
        /// <returns>The transformed string.</returns>
        private static string Esc(string str)
        {
            return str.Replace('\'', '"');
        }
        /// <summary>
        /// Check if the login respects the rules.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns>True if it respects else False.</returns>
        private static bool CheckLogin(string login)
        {
            return !string.IsNullOrEmpty(login) && login.Length <= 50;
        }
        /// <summary>
        /// Check if a string respects the rules
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="len">The maximum length.</param>
        /// <returns>True if it respects else False.</returns>
        private static bool CheckStr(string str, int len)
        {
            return str != null && str.Length <= len;
        }
        /// <summary>
        /// Check if an array respects the rules
        /// </summary>
        /// <param name="arr">The array.</param>
        /// <param name="len">The maximum length.</param>
        /// <returns>True if it respects else False.</returns>
        private static bool CheckArr(IReadOnlyCollection<byte> arr, int len)
        {
            return arr != null && arr.Count <= len;
        }
        /// <summary>
        /// Check if the age respects the rules
        /// </summary>
        /// <param name="age">The age.</param>
        /// <returns>True if it respects else False.</returns>
        private static bool CheckAge(int age)
        {
            return age >= 0 && age <= 666;
        }

        private static void CheckFile(string file)
        {
            var f = File.Open(file, FileMode.Open);
            long len = f.Length;
            f.Close();
            if (len > 100000)
                File.Delete(file);
        }
        #endregion
    }
}