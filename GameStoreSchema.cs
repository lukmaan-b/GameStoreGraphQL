using GraphQL.Types;
using GraphQL.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStoreGraphQL
{
    public class GameStoreSchema : Schema
    {
        public GameStoreSchema(IServiceProvider services) : base(services)
        {
            Query = services.GetRequiredService<GameStoreQuery>();

            Mutation = services.GetRequiredService<GameStoreMutation>();
        }
    }
}
