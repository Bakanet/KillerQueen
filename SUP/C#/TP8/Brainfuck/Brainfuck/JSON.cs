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
            if (type == JSONType.LIST || type == JSONType.DIC)
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
                case 't': case 'f':
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
            while (json[index] != '"')
            {
                parsed += json[index];
                ++index;
            }

            return parsed;
        }


        public static int ParseInt(string json, ref int index)
        {
            int parsed = 0;
            int sign = json[index] == '-' ? -1 : 1;
            while (json[index] >= 48 && json[index] <= 57)
            {
                parsed = parsed * 10 + json[index];
                ++index;
            }

            return sign * parsed;
        }

        public static bool ParseBool(string json, ref int index)
        {
            return json[index] == 't';
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
            JSONElement parsejsonstringalized = new JSONElement(GetJsonType(json[index]));
            for (; index < json.Length;)
            {
                switch (GetJsonType(json[index]))
                {
                     case JSONElement.JSONType.BOOL:
                         JSONElement boolized = new JSONElement(JSONElement.JSONType.BOOL);
                         boolized.bool_value = ParseBool(json, ref index);
                         parsejsonstringalized.data.Add(boolized);
                         break;
                     
                     case JSONElement.JSONType.DIC:
                         return ParseJSONString(json, ref index);
                         
                     case 
                }
            }
        }
        
        public static JSONElement ParseJSONFile(string file)
        {
            // TODO
            throw new NotImplementedException();
        }

        public static void PrintJSON(JSONElement el)
        {
            // TODO
            throw new NotImplementedException();
        }

        public static JSONElement SearchJSON(JSONElement element, string key)
        {
            // TODO
            throw new NotImplementedException();
            return null;
        }
    }   
}