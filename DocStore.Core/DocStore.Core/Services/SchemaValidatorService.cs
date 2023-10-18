using System.Collections.Generic;
using System.Threading.Tasks;
using NJsonSchema;
using NJsonSchema.Validation;

namespace DocStore.Core.Services
{
    public class SchemaValidatorService
    {
        public JsonSchema GetSchemaFromType<T>()
        {
            return JsonSchema.FromType<T>();
        }

        public async Task<JsonSchema> GetSchemaFromJsonAsync(string schemaString)
        {
            return await JsonSchema.FromJsonAsync(schemaString);
        }

        public ICollection<ValidationError> Validate(JsonSchema schema, string jsonString)
        {
            return schema.Validate(jsonString);
        }
    }
}