using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Implementations;
using ProductAPI.Interfaces;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;
        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        // GET: api/Login/CheckUserLogin
        [HttpPost("CheckUserLogin")]
        public async Task<IActionResult> CheckUserLogin(LoginUserModel loginUser)
        {
            try
            {
                if (loginUser.UserName == "" || loginUser.Password == "")
                {
                    return Unauthorized();
                }
                bool userValidated = await _loginRepository.CheckUserLoginAsync(loginUser);
                if (userValidated == true)
                {
                    return StatusCode(200);
                }
                else
                {
                    //UnAuthorized 401
                    return StatusCode(401);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
