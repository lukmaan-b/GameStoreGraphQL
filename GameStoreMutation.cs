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
    public class GameStoreMutation : ObjectGraphType
    {
        public GameStoreMutation(IDataRepository repository)
        {
            Field<ProductType>("createProduct",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProductInputType>> { Name = "product" }),
                resolve: ctx=> 
                {
                    return repository.AddProduct(ctx.GetArgument<Product>("product"));
                });
        }
    }
}
