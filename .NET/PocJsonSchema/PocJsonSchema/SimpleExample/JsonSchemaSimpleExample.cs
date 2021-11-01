using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Serialization;
using System;

namespace PocJsonSchema.SimpleExample
{
    public static class JsonSchemaSimpleExample
    {
        public static bool IsValidCompany(object company) => JObject.FromObject(company, GetCustomizedJsonSerializer()).IsValid(GetJsonSchemaForCompany());

        public static string ValidateWithErrors(object company)
        {
            try
            {
                JObject.FromObject(company, GetCustomizedJsonSerializer()).Validate(GetJsonSchemaForCompany());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return null;
        }

        private static JSchema GetJsonSchemaForCompany()
        {
            JSchema companyJsonSchema = JSchema.Parse(@"{
            '$schema': 'https://json-schema.org/draft/2020-12/schema',
            '$id': 'https://example.com/product.schema.json',
            'type': 'object',
            'properties': {
                'companyId': {'description': 'Unique identifier for company', 'type':'string'},
                'companyName': {'description': 'Name of company', 'type': 'string'},
                'customerIds': { 'description': 'Array of customer ids', 'type': 'array', 'items': { 'type': 'string' }, 'minItems': 1, 'uniqueItems' : true}
            },
            'required': ['companyId', 'customerIds']
            }");

            return companyJsonSchema;
        }

        private static JsonSerializer GetCustomizedJsonSerializer() =>
             new()
             {
                 ContractResolver = new DefaultContractResolver
                 {
                     NamingStrategy = new CamelCaseNamingStrategy()
                 }
             };
    }
}