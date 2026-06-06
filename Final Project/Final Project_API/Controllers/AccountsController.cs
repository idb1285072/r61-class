using Azure.Core;
using Final_Project_API.TokenUtility;
using Final_Project_CORE.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Final_Project_API.DTOs;

namespace Final_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenServrice _tokenmanager;
        public AccountsController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager,
             ITokenServrice tokenmanager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._tokenmanager = tokenmanager;
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
                    //new Claim(ClaimTypes.Role, role ?? "")
                };

                // Generate JWT access token and refresh token
                string accessToken = _tokenmanager.GetToken(claims);
                return Ok(new DTOs.AccessToken { Token = accessToken });
            }
            else
            {
                return Unauthorized();
            }

        }
    }
}
