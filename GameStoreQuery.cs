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
        }
    }
}
