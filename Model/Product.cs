﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStoreGraphQL.Model
{
    public class Product
    {
        public string Title { get; set; }

        public string Genre { get; set; }

        public decimal Price { get; set; }
    }
}