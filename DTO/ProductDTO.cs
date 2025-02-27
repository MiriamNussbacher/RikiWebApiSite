﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        public string? Name { get; set; }

        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string? Image { get; set; }
    }

}
