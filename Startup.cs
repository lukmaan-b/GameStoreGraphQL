using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GameStoreGraphQL
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    context.Response.Redirect("/ui/graphqli");
                });

                endpoints.MapPost("/graphql", async context =>
                {
                    var request = await JsonSerializer.DeserializeAsync<GraphQLRequest>(context.Request.Body, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    var schema =  new Schema { Query = new GameStoreQuery()};

                    var result = await new DocumentExecuter().ExecuteAsync(doc =>
                    {
                        doc.Schema = schema;
                        doc.Query = request.Query;
                    });

                    await new DocumentWriter().WriteAsync(context.Response.Body, result);
                });
            });
        }
    }
}
