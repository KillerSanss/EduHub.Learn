using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EduHub.StudentService.Api;

public class FileUploadOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var fileUploadMime = "multipart/form-data";
        if (operation.RequestBody != null && operation.RequestBody.Content.Any(x => x.Key.Equals(fileUploadMime, StringComparison.InvariantCultureIgnoreCase)))
        {
            var schema = operation.RequestBody.Content[fileUploadMime].Schema;
            
            schema.Properties.Remove("ContentType");
            schema.Properties.Remove("ContentDisposition");
            schema.Properties.Remove("Headers");
            schema.Properties.Remove("Length");
            schema.Properties.Remove("Name");
            schema.Properties.Remove("FileName");
            
            schema.Properties["file"] = new OpenApiSchema
            {
                Type = "string",
                Format = "binary"
            };
        }
    }
}