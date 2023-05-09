using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Services;
using Entities;
using AutoMapper;
using DTO; 

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
 
namespace ShopSite.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUsersService _usersService;
        IMapper _mapper; 
        public UsersController(IUsersService usersService,IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            User user = await _usersService.getUsersById(id);
            UserDTO userDTO = _mapper.Map<User, UserDTO>(user);
            return userDTO != null ? Ok(userDTO) : BadRequest("User didn't found");

        }



        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> loginByEmailAndPassword([FromBody] UserDTO userFromBody)
        {
            User user = _mapper.Map<UserDTO, User>(userFromBody);
            User userLogin = await _usersService.getUserByEmailAndPassword(user);
            UserDTO userDTO = _mapper.Map<User, UserDTO>(userLogin);
            return userDTO != null ? Ok(userDTO) : Unauthorized();
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody] UserDTO userFromBody)
        {
            User user = _mapper.Map<UserDTO, User>(userFromBody);
            User userCreated = await _usersService.createUser(user);
            UserDTO userDTO = _mapper.Map<User, UserDTO>(userCreated);
            return userDTO == null ? BadRequest("Password isn't strong") : CreatedAtAction(nameof(Post), new { id = userDTO.Id }, userDTO);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> Put(int id, [FromBody] UserDTO userToUdate)
        {
            User user = _mapper.Map<UserDTO, User>(userToUdate);
            User userUdated =await _usersService.updateUser(id, user);
            UserDTO userDTO = _mapper.Map<User, UserDTO>(userUdated); 
            return userDTO != null ? Ok(userDTO) : BadRequest("User didn't found");
        }    
    
    }
}
