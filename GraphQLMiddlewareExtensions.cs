using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStoreGraphQL
{
    public static class GraphQLMiddlewareExtensions
    {
        public static IApplicationBuilder UseGraphQL(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GraphQLMiddleware>();
        }

        public static IServiceCollection AddGraphQL(this IServiceCollection services, Action<GrapQLOptions> action)
        {
            return services.Configure(action);
        }
    }
}
