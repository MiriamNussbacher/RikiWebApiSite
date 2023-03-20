using Entities;

namespace Services
{
    public interface IProductService
    {
        Task<Product> createProduct(Product newProduct);
        Task<List<Product>> getAllProducts(string name, List<int> categoriesId, string description, int minPrice, int maxPrice);
        Task<Product> getProductById(int id);
    }
}