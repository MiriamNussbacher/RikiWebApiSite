using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories; 

namespace Services
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> getAllProducts(string? name, List<int> categoriesId, string? description, int? minPrice, int? maxPrice)
        {
            return await _productRepository.getAllProducts(name,categoriesId,description,minPrice,maxPrice);
        }

        public async Task<Product> getProductById(int id)
        {
            return await _productRepository.getProductById(id);
        }
        public async Task<Product> createProduct(Product newProduct)
        {
            return await _productRepository.createProduct(newProduct);


        }
    }
}
