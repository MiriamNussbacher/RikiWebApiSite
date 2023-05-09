using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using AutoMapper;
using DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        IMapper _mapper; 
        public ProductsController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper; 
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> Get([FromQuery]  List<int> categoriesId, string? name,string? description,int? minPrice, int? maxPrice)
        
        {
            List<Product> products = await _productService.getAllProducts(name, categoriesId, description, minPrice, maxPrice);
            List<ProductDTO> productsDTO = _mapper.Map<List<Product>, List<ProductDTO>>(products); 
            return productsDTO != null ? Ok(productsDTO) : NoContent();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            Product product = await _productService.getProductById(id);
            ProductDTO productDTO = _mapper.Map<Product, ProductDTO>(product);
            return productDTO != null ? Ok(productDTO) : NoContent();
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Post([FromBody] ProductDTO productFromBody)
        {
            Product product = _mapper.Map<ProductDTO, Product>(productFromBody); 
            Product productCreated = await _productService.createProduct(product);
            ProductDTO productDTO = _mapper.Map<Product, ProductDTO>(productCreated);
            return CreatedAtAction(nameof(Post), new { ProductId = productDTO.ProductId }, productDTO);

        }
    }
}
