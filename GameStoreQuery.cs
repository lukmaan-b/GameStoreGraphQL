using GameStoreGraphQL.Model;
using GameStoreGraphQL.Model.GraphQLTypes;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStoreGraphQL
{
    public class GameStoreQuery : ObjectGraphType
    {
        public GameStoreQuery()
        {
            Field<StringGraphType>("hello", resolve: ctx => "World");

            Field<ProductType>("product", resolve: context =>
            {
                return new Product { Title = "Mario", Genre = "Platformer", Price = 34.99M };
            });
        }
    }
}
