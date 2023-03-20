using Entities;

namespace Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> createCategory(Category newCategory);
        Task<List<Category>> getAllCategories();
        Task<Category> getCategoryById(int id);
    }
}