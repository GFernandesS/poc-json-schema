using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Serialization;

namespace PocJsonSchema.AdvancedExample
{
    public static class SchemaValidator
    {
        public static bool IsValidToSchema<T>(BaseSchema<T> schema, object objectToValidate)
        {
            var correspondentJObject = JObject.FromObject(objectToValidate, new JsonSerializer()
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            });

            return correspondentJObject.IsValid(GetSchema(schema));
        }

        private static JSchema GetSchema<T>(BaseSchema<T> schema)
        {
            var schemaInJson = JsonConvert.SerializeObject(schema, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate
            });

            return JSchema.Parse(schemaInJson);
        }
    }
}
