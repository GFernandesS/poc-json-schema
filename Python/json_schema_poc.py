from jsonschema import validate

schema = {
    '$schema': 'https://json-schema.org/draft/2020-12/schema',
    '$id': 'https://example.com/product.schema.json',
    'type': 'object',
            'properties': {
                'companyId':
                {'description': 'Unique identifier for company',
                 'type': 'string'
                 },
                'companyName':
                {
                    'description': 'Name of company',
                    'type': 'string'
                },
                'customerIds': {
                    'description': 'Array of customer ids', 'type': 'array',
                    'items': {'type': 'string'},
                    'minItems': 1,
                    'uniqueItems': True
                }
            },
    'required': ['companyId']
}

try:
    validate(instance={"companyId": "123"}, schema=schema)
except Exception as e:
    print(e.message)
