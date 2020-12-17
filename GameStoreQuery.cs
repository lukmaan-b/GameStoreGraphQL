using GameStoreGraphQL.Data;
using GameStoreGraphQL.Model;
using GameStoreGraphQL.Model.GraphQLTypes;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStoreGraphQL
{
    public class GameStoreQuery : ObjectGraphType
    {
        public GameStoreQuery(IDataRepository repository)
        {
            Field<StringGraphType>("hello", resolve: ctx => "World");

            Field<ProductType>("product",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }), 
                resolve: context =>
            {

                    var id = context.GetArgument<int>("id");
                    return repository.GetProductById(id);
                

            });

            Field<ListGraphType<ProductType>>("products", resolve: ctx => repository.GetAllProducts());

            //Field<ProductType>("product", arguments: new QueryArguments(new QueryArgument<StringGraphType> {Name="genre" })){ }
        }
    }
}
