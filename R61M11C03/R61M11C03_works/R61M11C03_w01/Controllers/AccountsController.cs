using System.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using R61M11C03_w01.DTOs;
using R61M11C03_w01.Models;
using R61M11C03_w01.Security;

namespace R61M11C03_w01.Controllers
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
    public string Get()
    {
            return "Hello world";
    }
        [HttpPost]
        public async Task<IActionResult> Register(UserDTO entity)
        {
            var user = new ApplicationUser
            {
                Email = entity.Email,
                UserName = entity.Email
            };
            IdentityResult result =await _userManager.CreateAsync(user,entity.Password);
            if (result.Succeeded) {
                return Created("",user);
            }
            else if(result.Errors.Count()>0)
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
            
        var result= await   _signInManager.PasswordSignInAsync( entity.Email,entity.Password,false,lockoutOnFailure:false);
            if (result.Succeeded) {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, entity.Email ?? ""),
                    //new Claim(ClaimTypes.Role, role ?? "")
                };

                // Generate JWT access token and refresh token
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
