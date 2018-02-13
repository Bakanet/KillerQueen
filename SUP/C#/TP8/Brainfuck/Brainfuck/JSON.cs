using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Brainfuck
{
    class JSONElement
    {
        public enum JSONType
        {
            DIC,
            LIST,
            STR,
            NB,
            BOOL,
            NULL
        }

        private JSONType type;

        public bool bool_value;
        public int int_value;
        public string string_value;
        public List<JSONElement> data;
        public List<string> key;

        public JSONElement(JSONType type)
        {
            this.type = type;
            if (type == JSONType.LIST || type == JSONType.DIC)
                this.data = new List<JSONElement>();
            if (type == JSONType.DIC)
                this.key = new List<string>();
        }

        public JSONType Type
        {
            get { return this.type; }
        }
    }

    static class JSON
    {
        public static JSONElement.JSONType GetJsonType(char c)
        {
            switch (c)
            {
                case '"':
                    return JSONElement.JSONType.STR;
                case 't':
                case 'f':
                    return JSONElement.JSONType.BOOL;
                case '[':
                    return JSONElement.JSONType.LIST;
                case '{':
                    return JSONElement.JSONType.DIC;
                case 'n':
                    return JSONElement.JSONType.NULL;
                default:
                    return JSONElement.JSONType.NB;
            }
        }

        public static string ParseString(string json, ref int index)
        {
            string parsed = "";
            ++index;
            while (json[index] != '"')
            {
                parsed += json[index];
                ++index;
            }

            ++index;

            return parsed;
        }


        public static int ParseInt(string json, ref int index)
        {
            string parsed = "";
            int sign = json[index] == '-' ? -1 : 1;
            if (sign == -1)
                ++index;
            while (json[index] >= 48 && json[index] <= 57)
            {
                parsed += json[index];
                ++index;
            }

            return sign * int.Parse(parsed);
        }

        public static bool ParseBool(string json, ref int index)
        {
            if (json[index] == 't')
            {
                index += 4;
                return true;
            }

            index += 5;
            return false;
        }

        public static void EatBlank(string json, ref int index)
        {
            while (json[index] == 32 || json[index] == 10 || json[index] == 9)
            {
                ++index;
            }
        }

        public static JSONElement ParseJSONString(string json, ref int index)
        {
            JSONElement parsed = new JSONElement(GetJsonType(json[index]));

            for (; index < json.Length;)
            {
                EatBlank(json, ref index);

                if (json[index] == ',')
                {
                    ++index;
                    EatBlank(json, ref index);
                }

                EatBlank(json, ref index);
                
                switch (GetJsonType(json[index]))
                {
                    case JSONElement.JSONType.BOOL:
                        JSONElement boolized = new JSONElement(JSONElement.JSONType.BOOL);
                        boolized.bool_value = ParseBool(json, ref index);
                        return boolized;

                    case JSONElement.JSONType.DIC:
                        ++index;
                        EatBlank(json, ref index);
                        for (; index < json.Length && json[index] != '}';)
                        {
                            string key = ParseString(json, ref index);
                            parsed.key.Add(key);
                            ++index;
                            EatBlank(json, ref index);
                            parsed.data.Add(ParseJSONString(json, ref index));
                            ++index;
                            EatBlank(json, ref index);
                        }

                        return parsed;


                    case JSONElement.JSONType.STR:

                        JSONElement stringed = new JSONElement(JSONElement.JSONType.STR);
                        stringed.string_value = ParseString(json, ref index);
                        ++index;
                        return stringed;

                    case JSONElement.JSONType.LIST:
                        ++index;
                        EatBlank(json, ref index);
                        for (; json[index] != ']';)
                        {
                            parsed.data.Add(ParseJSONString(json, ref index));
                        }
                        return parsed;

                    case JSONElement.JSONType.NB:
                        JSONElement gimmeyournumbersweetie = new JSONElement(JSONElement.JSONType.NB);
                        gimmeyournumbersweetie.int_value = ParseInt(json, ref index);
                        return gimmeyournumbersweetie;

                    case JSONElement.JSONType.NULL:
                        return new JSONElement(JSONElement.JSONType.NULL);
                }
            }

            return parsed;
        }


        public static JSONElement ParseJSONFile(string file)
        {
            int index = 0;
            return ParseJSONString(File.ReadAllText(file), ref index);
        }

        public static void PrintJSON(JSONElement el)
        {
            string printed = "";

            switch (el.Type)
            {
                case JSONElement.JSONType.DIC:
                    Console.WriteLine("{");
                    for (int i = 0; i < el.data.Count; ++i)
                    {
                        Console.Write("\"" + el.key[i] + "\": ");
                        PrintJSON(el.data[i]);
                        if (i < el.data.Count - 1)
                            Console.Write(',');
                        Console.WriteLine();
                    }
                    Console.WriteLine("}");
                    break;

                case JSONElement.JSONType.LIST:
                    Console.WriteLine("[");
                    for (int i = 0; i < el.data.Count; ++i)
                    {
                        PrintJSON(el.data[i]);
                        if (i < el.data.Count - 1)
                            Console.Write(',');
                    }
                    Console.WriteLine();
                    Console.Write("]");
                    break;

                case JSONElement.JSONType.BOOL:
                    Console.Write(el.bool_value);
                    break;

                case JSONElement.JSONType.NB:
                    Console.Write(el.int_value);
                    break;

                case JSONElement.JSONType.STR:
                    Console.Write("\"" + el.string_value + "\"");
                    break;
            }
        }

        public static JSONElement SearchJSON(JSONElement element, string key)
        {
            // TODO
            throw new NotImplementedException();
            return null;
        }
    }
}