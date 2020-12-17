using GameStoreGraphQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GameStoreGraphQL.Data
{
    public class DataRepository : IDataRepository
    {

        //private IEnumerable<Product> Products = new Product[]
        //{
        //    new Product {Id = 1, Title = "Mario", Genre = "Platformer" , Price = 45.99M}
        //};

        private readonly ApplicationDbContext _dbContext;

        public DataRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Products.First(p => p.Id == id);
        }

        public Product AddProduct(Product product)
        {
            var addedEntity = _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public IEnumerable<Product> GetProductsByGenre(string genre)
        {
            return _dbContext.Products.Where(p => p.Genre == genre).ToList(); ;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }
    }
}
