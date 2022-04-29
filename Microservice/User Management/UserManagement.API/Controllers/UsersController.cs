using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UserManagement.Models.Login;
using UserManagement.Models.Register;
using UserManagement.Models.UpdatePassword;
using UserManagement.Service.Interface;

namespace UserManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
  
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
       

        public UsersController(
            IUserService userService
            )
        {
            _userService = userService;

        }

        // POST: api/<UsersController>
        [HttpPost("login")]
        [ProducesResponseType(typeof(UserDetails), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] Login LoginModel)
        {
            try
            {
                var result =await _userService.LoginAsync(LoginModel);

                if (result == null)
                    return BadRequest(new { message = "Not Found" });

                return Ok(result);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromHeader(Name = "email")] string email, [FromHeader(Name = "password")] string password, Users userDetail)
        {
            var result = await _userService.Register(email, password, userDetail);

            if (result == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(result);
        }

        [HttpPost("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePassword updatePassword)
        {
            try
            {
                var result = await _userService.UpdatePasswordAync(updatePassword);

                if (result == null)
                    return BadRequest(new { message = "Not Found" });

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
