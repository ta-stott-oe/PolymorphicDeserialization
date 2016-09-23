using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolymorphicDeserializationExample.Models
{
    public abstract class JsonCreationConverter<T>: JsonConverter
    {
        /// <summary>
        /// this is very important, otherwise serialization breaks!
        /// </summary>
        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }
        /// <summary> 
        /// Create an instance of objectType, based properties in the JSON object 
        /// </summary> 
        /// <param name="jObject">contents of JSON object that will be 
        /// deserialized</param> 
        ///  
        /// <returns></returns> 
        protected abstract Type GetTargetType(T baseObject);

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType,
          object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            // Load JObject from stream 
            JObject jObject = JObject.Load(reader);

            // Deserialize to base type
            var baseObject = serializer.Deserialize<T>(jObject.CreateReader());

            // Get target type based on JObject 
            Type targetType = GetTargetType(baseObject);

            return serializer.Deserialize(jObject.CreateReader(), targetType);
        }

        public override void WriteJson(JsonWriter writer, object value,
          JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}