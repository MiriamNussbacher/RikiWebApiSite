using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordsController : ControllerBase
    {
        
        IValidPasswordService _validPasswordService;
        public PasswordsController(IValidPasswordService validPasswordService)
        {
            _validPasswordService = validPasswordService;
        }


        // POST api/<PasswordsController>
        [HttpPost]
        public ActionResult<int> Post([FromBody] string password)
        {
            
            return _validPasswordService.scoreStrenghPassword(password);

        }


    }
}
