using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repositories; 
namespace Services
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<List<Category>> getAllCategories()
        {
            return await _categoryRepository.getAllCategories();
        }

        public async Task<Category> createCategory(Category newCategory)
        {
            return await _categoryRepository.createCategory(newCategory); 
        }

        public async Task<Category> getCategoryById(int id)
        {
           return await _categoryRepository.getCategoryById(id); 
        }
    }
}
