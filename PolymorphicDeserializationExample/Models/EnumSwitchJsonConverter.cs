using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolymorphicDeserializationExample.Models
{
    /// <summary>
    /// Converts objects with a common base type to their concrete sub-type, using an enum property on the base type to determine the sub-type.
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <typeparam name="TBase"></typeparam>
    public class EnumSwitchJsonConverter<TEnum, TBase>: JsonConverter where TEnum: struct
    {
        private readonly string enumPropertyName;
        private readonly IDictionary<TEnum, Type> mappings;

        public EnumSwitchJsonConverter(string enumPropertyName, IDictionary<TEnum, Type> mappings)
        {
            this.enumPropertyName = enumPropertyName;
            this.mappings = mappings;
        }

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

        public override bool CanConvert(Type objectType)
        {
            return typeof(TBase).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType,
          object existingValue, JsonSerializer serializer)
        {

            if (reader.TokenType == JsonToken.Null)
                return null;
            // Load JObject from stream 
            JObject jObject = JObject.Load(reader);

            // Get type value
            var enumProperty = jObject.Properties().Where(property => property.Name == this.enumPropertyName).FirstOrDefault();

            if (enumProperty == null)
            {
                throw new JsonSerializationException($"Cannot deserialize object of base type {typeof(TBase).Name} because it does not have expected type property '{this.enumPropertyName}'.");
            }

            TEnum enumValue;
            if (!Enum.TryParse(enumProperty.Value.ToString(), out enumValue))
            {
                throw new JsonSerializationException($"Cannot deserialize object of base type {typeof(TBase).Name} because its type value is unrecognized: '{enumProperty.Value.ToString()}'.");
            }

            // Map to type
            Type targetType;
            if (!this.mappings.TryGetValue(enumValue, out targetType))
            {
                throw new JsonSerializationException($"Cannot deserialize object of base type {typeof(TBase).Name} because no type mapping exists for '{enumValue}'.");
            }

            return jObject.ToObject(targetType);
        }

        public override void WriteJson(JsonWriter writer, object value,
          JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    } 
}