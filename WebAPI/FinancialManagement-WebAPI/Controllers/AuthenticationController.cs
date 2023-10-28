using FinancialManagement.Domain.Model.User;
using FinancialManagement.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using System.Security.Cryptography;

namespace FinancialManagement_WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class AuthenticationController : ControllerBase
    {
        public static User user = new User();
        private readonly IUserService _userService;
        public AuthenticationController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpGet, Authorize]
        public ActionResult<string> GetMe()
        {
            var userName = _userService.GetMyName();
            return Ok(userName);
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.Name = request.User;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return Ok(user);
        }


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
