using System.Text;
using Newtonsoft.Json;

namespace Rednit_Lite
{
    /// <summary>
    ///   Json Serialize and serialize of an object.
    /// </summary>
    internal static class Formatter
	{
	    /// <summary>
	    ///   Serialize an object to a Json stirng and then transforms it into a byte array.
	    /// </summary>
	    /// <typeparam name="T">The type of the object to serialize.</typeparam>
	    /// <param name="obj">The object to serialize.</param>
	    /// <returns>The result of the serialization, a byte array.</returns>
	    public static byte[] ToByteArray<T>(T obj)
		{
			if (obj == null)
				return null;
			var json = JsonConvert.SerializeObject(obj);
			var message = Encoding.UTF8.GetBytes(json);
			return message;
		}

	    /// <summary>
	    ///   Deserialize a byte array to a Json string and then transforms it in the asked object.
	    /// </summary>
	    /// <typeparam name="T">The type of the object to deserialize.</typeparam>
	    /// <param name="data">The object to deserialize.</param>
	    /// <returns>The result of the deserialization, the object of type T.</returns>
        public static T FromByteArray<T>(byte[] data)
        {
            if (data == null)
                return default(T);
            string message = Encoding.UTF8.GetString(data);

            try
            {
                T obj = JsonConvert.DeserializeObject<T>(message);
                return obj;
            }
            catch (JsonReaderException)
            {
                return default(T);
            }    
        }
	}
}