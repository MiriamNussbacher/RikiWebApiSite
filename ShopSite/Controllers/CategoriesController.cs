using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            List<Category> categories = await _categoryService.getAllCategories();
            return categories != null ? Ok(categories) : NoContent();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            Category category = await _categoryService.getCategoryById(id);
            return category != null ? Ok(category) : NoContent();

        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<Category>> Post([FromBody] Category categoryFromBody)
        {
            Category category = await _categoryService.createCategory(categoryFromBody);
            return CreatedAtAction(nameof(Post), new { CategoryId = category.CategoryId }, category);

        }

        //    // PUT api/<ValuesController>/5
        //    [HttpPut("{id}")]
        //    public void Put(int id, [FromBody] string value)
        //    {
        //    }

        //    // DELETE api/<ValuesController>/5
        //    [HttpDelete("{id}")]
        //    public void Delete(int id)
        //    {
        //    }
        //}
    }
}