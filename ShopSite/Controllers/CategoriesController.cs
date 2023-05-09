using AutoMapper;
using DTO;
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
        IMapper _mapper; 
        public CategoriesController(ICategoryService categoryService ,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper; 
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> Get()
        {
            List<Category> categories = await _categoryService.getAllCategories();
            List<CategoryDTO> categoriesDTO = _mapper.Map<List<Category>, List<CategoryDTO>>(categories);
            return categoriesDTO != null ? Ok(categoriesDTO) : NoContent();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            Category category = await _categoryService.getCategoryById(id);
            CategoryDTO categoryDTO = _mapper.Map<Category, CategoryDTO>(category);
            return categoryDTO != null ? Ok(categoryDTO) : NoContent();

        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> Post([FromBody] CategoryDTO categoryFromBody)
        {
            Category category = _mapper.Map<CategoryDTO, Category>(categoryFromBody);
            Category categoryCreated = await _categoryService.createCategory(category);
            CategoryDTO categoryDTO = _mapper.Map<Category, CategoryDTO>(categoryCreated);
            return CreatedAtAction(nameof(Get), new { CategoryId = categoryDTO.CategoryId }, categoryDTO);
            //return CreatedAtAction(nameof(Get), new { CategoryId = categoryCreated.CategoryId }, categoryFromBody);


        }
    }
}