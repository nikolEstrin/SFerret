using Microsoft.AspNetCore.Mvc;
using sferretAPI.Models;
using sferretAPI.Services.IServices;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace sferretAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;
        public UserController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(User user)
        {
            var result = await _userService.Register(user);
            if (result.Id == 0)
                return BadRequest();
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(User user)
        {
            var result = await _userService.Login(user);
            if (result == null)
                return NotFound("No such user or password");
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _userService.Get(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("Name/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var result = await _userService.Get(name);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
