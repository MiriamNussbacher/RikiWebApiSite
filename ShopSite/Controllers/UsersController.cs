using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Services;
using Entities; 

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopSite.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UsersService usersService = new UsersService();

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
           User user = usersService.getUsersById(id); 
           
           return user!=null ? Ok(user): BadRequest("User didn't found");

        }

        // GET api/<UsersController>/5
        //[HttpGet()]


        [HttpPost("login")]
        public ActionResult<User> loginByEmailAndPassword([FromBody] User userFromBody)
        {
            User user = usersService.getUserByEmailAndPassword(userFromBody);
            return user != null ? Ok(user) : Unauthorized();
        }


        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User userFromBody)
        {
           
            User user = usersService.createUser(userFromBody);
            return user == null ? BadRequest("Password isn't strong!"): CreatedAtAction(nameof(Post), new { id = user.UserId }, user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User userToUdate)
        {
            User user = usersService.updateUser(id, userToUdate);

            return user != null ? Ok(user) : BadRequest("User didn't found");

        }    
    

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
