using GameStoreGraphQL.Model;
using GraphQL.Types;

namespace GameStoreGraphQL
{
    public class ProductInputType : InputObjectGraphType<Product>
    {
        public ProductInputType()
        {
            Name = "ProductInput";
            Field(p => p.Title);
            Field(p => p.Genre);
            Field(p => p.Price);
        }
    }
}