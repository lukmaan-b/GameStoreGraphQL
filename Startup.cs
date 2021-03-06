using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using GameStoreGraphQL.Data;
using GameStoreGraphQL.Model.GraphQLTypes;
using GraphQL;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
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

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();

            services.AddTransient<ISchema, GameStoreSchema>();

            services.AddTransient<GameStoreQuery>();
            services.AddTransient<GameStoreMutation>();
            services.AddTransient<ProductType>();
            services.AddTransient<ProductInputType>();
            services.AddGraphQL(options =>
            {
                options.EndPoint = "/graphql";
            });

            services.AddTransient<IDataRepository, DataRepository>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("InMemory"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseGraphiQLServer();
            app.UseGraphQL();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    context.Response.Redirect("/ui/graphiql");
                });

            });
            SeedData.EnsurePopulated(app);
        }
    }
}
