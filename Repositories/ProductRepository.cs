using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        ShopDbContext _shopDbContext;
        public ProductRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;


        }

        public async Task<List<Product>> getAllProducts(string name, List<int> categoriesId, string description, int minPrice, int maxPrice)
        { 
            return await _shopDbContext.Products.Include(product=>product.Category).ToListAsync();
        }

        public async Task<Product> getProductById(int id)
        {
            return await _shopDbContext.Products.FindAsync(id);
        }
        public async Task<Product> createProduct(Product newProduct)
        {
            await _shopDbContext.Products.AddAsync(newProduct);
            await _shopDbContext.SaveChangesAsync();
            return newProduct;
        }

    }
}
