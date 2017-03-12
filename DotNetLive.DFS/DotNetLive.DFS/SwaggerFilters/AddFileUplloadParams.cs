using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DotNetLive.DFS.SwaggerFilters
{
    public class AddFileUplloadParams : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.OperationId== "ApiFilePost")
            {
                operation.Consumes.Add("application/form-data");
                operation.Parameters = new List<IParameter>{
                    new NonBodyParameter(){
                         Name="file",
                         In="formData",
                         Required=true,
                         Type="file"
                    }

                };
            }
         
        }
    }
}
