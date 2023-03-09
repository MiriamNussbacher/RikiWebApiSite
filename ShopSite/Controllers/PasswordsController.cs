using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordsController : ControllerBase
    {

        ValidPasswordService validPasswordService = new();

        // POST api/<PasswordsController>
        [HttpPost]
        public ActionResult<int> Post([FromBody] string password)
        {
            return validPasswordService.scoreStrenghPassword(password);

        }


    }
}
