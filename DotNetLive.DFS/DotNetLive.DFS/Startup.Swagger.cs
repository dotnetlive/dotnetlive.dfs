using DotNetLive.DFS.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLive.DFS
{
    public partial class Startup
    {
        private void ConfigSwagger(IServiceCollection services)
        {
            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<SwaggerFilters.AddFileUplloadParams>();
                c.SwaggerDoc("v1", new Info { Title = "DotNetLive DFS API V1", Version = "v1" });
            });
        }

        private void ConfigSwagger(IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DNL DFS API V1");
             
                //c.InjectStylesheet("/swagger.css");
                //c.EnabledValidator();
                //c.BooleanValues(new object[] { 0, 1 });
                //c.DocExpansion("full");
                //c.InjectOnCompleteJavaScript("/swagger-ui/on-complete.js");
                //c.InjectOnFailureJavaScript("/swagger-ui/on-failure.js");
                //c.SupportedSubmitMethods(new[] { "get", "post", "put", "patch" });
                //c.ShowRequestHeaders();
                //c.ShowJsonEditor();
            });
        }
    }
}
