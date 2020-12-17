﻿using GameStoreGraphQL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStoreGraphQL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
