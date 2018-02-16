using System.Collections.Generic;
using System.Globalization;

namespace EpitaSpaceProgram.ACDC
{
    public static class Json
    {
        public static string Escape(string s)
        {
            return s.Replace("\\", "\\\\").Replace("\"", "\\\"");
        }

        public static string Escape(double d)
        {
            return d.ToString(CultureInfo.InvariantCulture);
        }

        public interface ISerializable
        {
            // Returns the text representation of an object.
            string Serialize();
        }

        public interface ISerializableList
        {
            // Returns the text representation of a list of objects.
            // Useful for objects that might compose other objects.
            IEnumerable<string> Serialize();
        }
    }
}