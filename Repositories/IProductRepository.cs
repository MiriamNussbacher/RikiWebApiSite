using Entities;

namespace Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> getAllProducts(string name, List<int> categoriesId, string description, int minPrice, int maxPrice);
        Task<Product> getProductById(int id);
        Task<Product> createProduct(Product newProduct);

    }
}