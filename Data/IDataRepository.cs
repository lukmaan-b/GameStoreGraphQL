using GameStoreGraphQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStoreGraphQL.Data
{
    public interface IDataRepository
    {
        public Product GetProductById();
        public IEnumerable<Product> GetProductsByGenre();


    }
}
