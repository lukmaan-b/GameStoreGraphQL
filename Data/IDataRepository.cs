using GameStoreGraphQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStoreGraphQL.Data
{
    public interface IDataRepository
    {
        public Product GetProductById(int id);
        public IEnumerable<Product> GetAllProducts();
        public IEnumerable<Product> GetProductsByGenre(string genre);
        public Product AddProduct(Product product);


    }
}
