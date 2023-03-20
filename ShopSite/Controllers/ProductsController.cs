using Entities;
using Microsoft.AspNetCore.Mvc;
using Services; 

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService; 
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get([FromQuery] string name=null,List<int> categoriesId=null,string description=null,int minPrice=0, int maxPrice=0)
        {
            List<Product> products = await _productService.getAllProducts(name, categoriesId, description, minPrice, maxPrice);
            return products != null ? Ok(products) : NoContent();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            Product product = await _productService.getProductById(id);
            return product != null ? Ok(product) : NoContent();
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody] Product productFromBody)
        {
            Product product = await _productService.createProduct(productFromBody);
            return CreatedAtAction(nameof(Post), new { ProductId = product.ProductId }, product);

        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
