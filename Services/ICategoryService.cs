using Entities;

namespace Services
{
    public interface ICategoryService
    {
        Task<List<Category>> getAllCategories();
        Task<Category> createCategory(Category newCategory);
        Task<Category> getCategoryById(int id);
    }
}