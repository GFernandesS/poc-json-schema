using Newtonsoft.Json;
using System.Collections.Generic;

namespace PocJsonSchema.AdvancedExample
{
    public class BaseSchema<T>
    {
        public BaseSchema(string schemaId, T properties, string draftSchema = "https://json-schema.org/draft/2020-12/schema", string description = null, 
            string title = null, List<string> requiredFields = null)
        {
            Id = schemaId;
            Schema = draftSchema;
            Properties = properties;
            Description = description;
            Title = title;
            Required = requiredFields;
            Type = "object";
        }

        [JsonProperty(PropertyName = "$id")]
        public string Id { get; private set; }

        [JsonProperty(PropertyName = "$schema")]
        public string Schema { get; private set; }
        public T Properties { get; private set; }
        public string Type { get; private set; }
        public string Description { get; private set; }
        public string Title { get; private set; }
        public List<string> Required { get; private set; }
    }
}