namespace SoMeTech.json.usJSON
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class JSONConvert
    {
        private static readonly string _COMMA = "@comma";
        private static JSONObject _json = new JSONObject();
        private static readonly string _SEMICOLON = "@semicolon";

        private static string Deserialize(string text)
        {
            text = StrEncode(text);
            int num = 0;
            string key = string.Empty;
            string pattern = "(//{[^//[//]//{//}]+//})|(//[[^//[//]//{//}]+//])";
            while (Regex.IsMatch(text, pattern))
            {
                foreach (Match match in Regex.Matches(text, pattern))
                {
                    key = "___key" + num + "___";
                    if (match.Value.Substring(0, 1) == "{")
                    {
                        _json.Add(key, DeserializeSingletonObject(match.Value));
                    }
                    else
                    {
                        _json.Add(key, DeserializeSingletonArray(match.Value));
                    }
                    text = text.Replace(match.Value, key);
                    num++;
                }
            }
            return text;
        }

        public static JSONArray DeserializeArray(string text)
        {
            return (_json[Deserialize(text)] as JSONArray);
        }

        public static JSONObject DeserializeObject(string text)
        {
            return (_json[Deserialize(text)] as JSONObject);
        }

        private static JSONArray DeserializeSingletonArray(string text)
        {
            JSONArray array = new JSONArray();
            foreach (Match match in Regex.Matches(text, "(//\"(?<value>[^,//\"]+)\")|(?<value>[^,//[//]]+)"))
            {
                string key = match.Groups["value"].Value;
                array.Add(_json.ContainsKey(key) ? _json[key] : StrDecode(key));
            }
            return array;
        }

        private static JSONObject DeserializeSingletonObject(string text)
        {
            JSONObject obj2 = new JSONObject();
            foreach (Match match in Regex.Matches(text, "(//\"(?<key>[^//\"]+)//\"://\"(?<value>[^,//\"]+)//\")|(//\"(?<key>[^//\"]+)//\":(?<value>[^,//\"//}]+))"))
            {
                string key = match.Groups["value"].Value;
                obj2.Add(match.Groups["key"].Value, _json.ContainsKey(key) ? _json[key] : StrDecode(key));
            }
            return obj2;
        }

        public static string SerializeArray(JSONArray jsonArray)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[");
            for (int i = 0; i < jsonArray.Count; i++)
            {
                if (jsonArray[i] is JSONObject)
                {
                    builder.Append(string.Format("{0},", SerializeObject((JSONObject) jsonArray[i])));
                }
                else if (jsonArray[i] is JSONArray)
                {
                    builder.Append(string.Format("{0},", SerializeArray((JSONArray) jsonArray[i])));
                }
                else if (jsonArray[i] is string)
                {
                    builder.Append(string.Format("{0},", jsonArray[i]));
                }
                else
                {
                    builder.Append(string.Format("{0},", jsonArray[i]));
                }
            }
            if (builder.Length > 1)
            {
                builder.Remove(builder.Length - 1, 1);
            }
            builder.Append("]");
            return builder.ToString();
        }

        public static string SerializeObject(JSONObject jsonObject)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("{");
            foreach (KeyValuePair<string, object> pair in jsonObject)
            {
                if (pair.Value is JSONObject)
                {
                    builder.Append(string.Format("{0}:{1},", pair.Key, SerializeObject((JSONObject) pair.Value)));
                }
                else if (pair.Value is JSONArray)
                {
                    builder.Append(string.Format("{0}:{1},", pair.Key, SerializeArray((JSONArray) pair.Value)));
                }
                else if (pair.Value is string)
                {
                    builder.Append(string.Format("{0}:{1},", pair.Key, pair.Value));
                }
                else
                {
                    builder.Append(string.Format("{0}:{1},", pair.Key, pair.Value));
                }
            }
            if (builder.Length > 1)
            {
                builder.Remove(builder.Length - 1, 1);
            }
            builder.Append("}");
            return builder.ToString();
        }

        private static string StrDecode(string text)
        {
            return text.Replace(_SEMICOLON, ":").Replace(_COMMA, ",");
        }

        private static string StrEncode(string text)
        {
            foreach (Match match in Regex.Matches(text, "//\"[^//\"]+///\""))
            {
                text = text.Replace(match.Value, match.Value.Replace(":", _SEMICOLON).Replace(",", _COMMA));
            }
            return text;
        }
    }
}

