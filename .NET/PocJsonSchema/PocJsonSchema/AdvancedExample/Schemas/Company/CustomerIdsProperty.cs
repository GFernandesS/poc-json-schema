namespace PocJsonSchema.AdvancedExample.Schemas.Company
{
    public class CustomerIdsProperty : ISchemaProperties
    {
        public string Description { get; set; }
        public string Type { get; set; }
        public int MinItems { get; set; }
        public bool UniqueIdentifier { get; set; }
    }
}