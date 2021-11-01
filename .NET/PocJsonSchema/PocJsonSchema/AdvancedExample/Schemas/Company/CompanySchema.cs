using PocJsonSchema.AdvancedExample.Schemas.Company;

namespace PocJsonSchema.AdvancedExample
{
    public class CompanySchema
    {
        public CompanySchema(ProductIdProperty productIdProperty, CustomerIdsProperty customerIdsProperty)
        {
            ProductId = productIdProperty;
            CustomerIds = customerIdsProperty;
        }

        public ProductIdProperty ProductId { get; set; }
        public CustomerIdsProperty CustomerIds { get; set; }
    }
}