using GameStoreGraphQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GameStoreGraphQL.Data
{
    public class DataRepository : IDataRepository
    {
        private readonly ApplicationDbContext _db;

        public DataRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Product GetProductById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductsByGenre()
        {
            throw new NotImplementedException();
        }
    }
}
