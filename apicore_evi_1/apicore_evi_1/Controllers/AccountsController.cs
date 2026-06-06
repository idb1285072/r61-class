using apicore_evi_1.DTO;
using apicore_evi_1.Models;
using apicore_evi_1.Secutity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace apicore_evi_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenmanager;
       
        public AccountsController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager,
             ITokenService tokenmanager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._tokenmanager = tokenmanager;
           
        }
        [HttpGet]
        public async Task<List<ApplicationUser>> GetUSER()
        {
            return _userManager.Users.ToList();
        }
       
        [HttpPost]
        public async Task<IActionResult> Register(UserDTO entity)
        {
            var user = new ApplicationUser
            {
                Email = entity.Email,
                UserName = entity.Email
            };
            IdentityResult result = await _userManager.CreateAsync(user, entity.Password);
            if (result.Succeeded)
            {
                return Created("", user);
            }
            else if (result.Errors.Count() > 0)
            {
                return BadRequest(result.Errors);
            }
            else
            {
                return Problem("Registration failed");
            }
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserDTO entity)
        {

            var result = await _signInManager.PasswordSignInAsync(entity.Email, entity.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, entity.Email ?? ""),
                   
                };
               
                string accessToken = _tokenmanager.GenerateAccessToken(claims);
                return Ok(accessToken);
            }
            else
            {
                return Unauthorized();
            }

        }


       
    }
}
