using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameStoreGraphQL
{
    public class GraphQLMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDocumentWriter _writer;
        private readonly IDocumentExecuter _executor;

        public GraphQLMiddleware(RequestDelegate next, IDocumentWriter writer, IDocumentExecuter executor)
        {
            _next = next;
            _writer = writer;
            _executor = executor;
        }

        public async Task InvokeAsync(HttpContext context, ISchema schema)
        {
            if(context.Request.Path.StartsWithSegments("/graphql") && string.Equals(context.Request.Method, "POST", StringComparison.OrdinalIgnoreCase))
            {
                var request = await JsonSerializer.DeserializeAsync<GraphQLRequest>(context.Request.Body, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                

                var result = await _executor.ExecuteAsync(doc =>
                {
                    doc.Schema = schema;
                    doc.Query = request.Query;
                });

                await _writer.WriteAsync(context.Response.Body, result);
            }
            else
            {
                await _next(context);
            }
        }
    }
}
