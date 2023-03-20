using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        ShopDbContext _shopDbContext;
        public CategoryRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext; 
        }
        public async Task<List<Category>> getAllCategories()
        {
            return await _shopDbContext.Categories.ToListAsync();
        }

        public async Task<Category> createCategory(Category newCategory)
        {
            await _shopDbContext.Categories.AddAsync(newCategory);
            await _shopDbContext.SaveChangesAsync();
            return newCategory; 
        }

        public async Task<Category> getCategoryById(int id)
        {
            return await _shopDbContext.Categories.FindAsync(id); 
        }
    }
}
