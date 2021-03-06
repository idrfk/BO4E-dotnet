﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BO4E.meta.LenientConverters
{
    public class LenientEnumListConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (!objectType.IsGenericType)
            {
                return false;
            }
            if (objectType.GetGenericTypeDefinition() != typeof(List<>))
            {
                return false;
            }
            Type expectedListElementType = objectType.GetGenericArguments()[0];
            return expectedListElementType.ToString().StartsWith("BO4E.ENUM");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader); // https://stackoverflow.com/a/47864946/10009545
            List<object> rawList = token.ToObject<List<object>>();
            Type expectedListElementType = objectType.GetGenericArguments()[0];
            Type expectedListType = typeof(List<>).MakeGenericType(expectedListElementType);
            object result = Activator.CreateInstance(expectedListType);
            if (rawList == null || rawList.Count == 0)
            {
                return result;
            }
            // First try to parse the List normally, in case it's formatted as expected
            foreach (var rawItem in rawList)
            {
                if (rawItem.GetType() == typeof(string) && Enum.IsDefined(expectedListElementType, rawItem.ToString()))
                {
                    // default. everything is as it should be :-)
                    object enumValue = Enum.Parse(expectedListElementType, rawItem.ToString());
                    ((IList)result).Add(enumValue);
                }
                else if (rawItem.GetType() == typeof(JObject))
                {
                    Dictionary<string, object> rawDict = ((JObject)rawItem).ToObject<Dictionary<string, object>>();
                    object rawObject = rawDict.Values.FirstOrDefault<object>();
                    object enumValue = Enum.Parse(expectedListElementType, rawObject.ToString());
                    ((IList)result).Add(enumValue);
                }
                else
                {
                    ((IList)result).Add(rawItem);
                }
            }
            return result;
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}