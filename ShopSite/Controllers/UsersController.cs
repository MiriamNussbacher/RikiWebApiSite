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
        public async Task<ActionResult<User>> Get(int id)
        {
           User user =await usersService.getUsersById(id); 
           
           return user!=null ? Ok(user): BadRequest("User didn't found");

        }

        // GET api/<UsersController>/5
        //[HttpGet()]


        [HttpPost("login")]
        public async Task<ActionResult<User>> loginByEmailAndPassword([FromBody] User userFromBody)
        {
            User user = await usersService.getUserByEmailAndPassword(userFromBody);
            return user != null ? Ok(user) : Unauthorized();
        }


        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User userFromBody)
        {
           
            User user = await usersService.createUser(userFromBody);
            return user == null ? BadRequest("Password isn't strong!"): CreatedAtAction(nameof(Post), new { id = user.UserId }, user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(int id, [FromBody] User userToUdate)
        {
            User user =await usersService.updateUser(id, userToUdate);

            return user != null ? Ok(user) : BadRequest("User didn't found");

        }    
    

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
