using PocJsonSchema.AdvancedExample;
using PocJsonSchema.AdvancedExample.Schemas.Company;
using PocJsonSchema.SimpleExample;
using System;
using System.Collections.Generic;
using static System.Console;

namespace PocJsonSchema
{
    class Program
    {
        private static readonly object validCompany = new
        {
            CompanyId = Guid.NewGuid().ToString(),
            CompanyName = "Empresa teste",
            CustomerIds = new List<string> { "1", "2", "3" }
        };

        private static readonly object invalidCompany = new
        {
            CompanyId = Guid.NewGuid().ToString(),
            CompanyName = "Empresa teste",
        };

        static void Main()
        {
            TestSimpleExample();
            TestAdvancedExample();
        }

        private static void TestSimpleExample()
        {
            var isValid = JsonSchemaSimpleExample.IsValidCompany(validCompany);

            WriteLine($"Company: {validCompany} \n Company is valid: {isValid}");

            var resultFromValidation = JsonSchemaSimpleExample.ValidateWithErrors(invalidCompany);

            WriteLine($"Company: {invalidCompany} \n Result from validation: {resultFromValidation ?? "Without errors"}");
        }

        private static void TestAdvancedExample()
        {
            var companySchema = new CompanySchema(new ProductIdProperty
            {
                Description = "Product unique ID",
                Type = "string" //Poderia haver um enumerador que define os types
            },
            new CustomerIdsProperty
            {
                Description = "Array of customer ids",
                Type = "array",
                UniqueIdentifier = true,
                MinItems = 1
            });

            var schema = new BaseSchema<CompanySchema>("www.example.com/schemas/company.schema.json", companySchema, requiredFields: new List<string> { "customerIds" });

            WriteLine($"Company is valid: {SchemaValidator.IsValidToSchema(schema, invalidCompany)}");
        }
    }
}