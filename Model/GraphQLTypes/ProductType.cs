using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;

namespace GameStoreGraphQL.Model.GraphQLTypes
{
    public class ProductType : ObjectGraphType<Product> 
    {
        public ProductType()
        {
            Field(p => p.Title);
            Field(p => p.Genre);
            Field(p => p.Price);
        }
    }
}
