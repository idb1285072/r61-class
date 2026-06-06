using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using R61M11C02_Models;
using R61M11C02_w01.Data;
using R61M11C02_w01.DTOs;

namespace R61M11C02_w01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly PurchaseContext _context;
        private UserManager<ApplicationUSer> _userManager;
        private SignInManager<ApplicationUSer> _signInManager;
        IConfiguration _configuration;
        public AccountController(PurchaseContext context,
            UserManager<ApplicationUSer> userManager,
            SignInManager<ApplicationUSer> signInManager,
            IConfiguration configuration
            )
        {
            this._context = context;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._configuration = configuration;
        }
        [HttpGet]
        public string GET()
        {
            return "Hello";
        }
        [HttpPost]
        public async Task<ActionResult> Register(RegisterDTO input)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newUser = new ApplicationUSer();
                    newUser.UserName = input.UserName;
                    newUser.Email = input.Email;
                    var result = await _userManager.CreateAsync(
                    newUser, input.Password);
                    if (result.Succeeded)
                    {

                        return StatusCode(201,
                        $"User '{newUser.UserName}' has been created.");
                    }
                    else
                        throw new Exception(
                        string.Format("Error: {0}", string.Join(" ",
                        result.Errors.Select(e => e.Description))));
                }
                else
                {
                    var details = new ValidationProblemDetails(ModelState);
                    details.Type =
                    "https://tools.ietf.org/html/rfc7231#section-6.5.1";
                    details.Status = StatusCodes.Status400BadRequest;
                    return new BadRequestObjectResult(details);
                }
            }
            catch (Exception e)
            {
                var exceptionDetails = new ProblemDetails();
                exceptionDetails.Detail = e.Message;
                exceptionDetails.Status =
                StatusCodes.Status500InternalServerError;
                exceptionDetails.Type =
                "https://tools.ietf.org/html/rfc7231#section-6.6.1";
                return StatusCode(
                StatusCodes.Status500InternalServerError,
                exceptionDetails);
            }
            }

        }
}
