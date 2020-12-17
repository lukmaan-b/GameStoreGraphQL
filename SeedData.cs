using GameStoreGraphQL.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStoreGraphQL.Model;

namespace GameStoreGraphQL
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext _context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (!_context.Products.Any())
            {
                _context.AddRange(
                    new Product { Title = "Mario", Genre = "Platformer", Price = 49.99M },
                    new Product { Title = "Pokemon", Genre = "RPG", Price = 25.99M },
                    new Product { Title = "Zelda", Genre = "Adventure", Price = 30.99M },
                    new Product { Title = "Monster Hunter", Genre = "RPG", Price = 59.99M }
                    );
                _context.SaveChanges();
            }
        }
        
    }
}
