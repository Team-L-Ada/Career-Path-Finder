namespace CareerPathFinder.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using CareerPathFinder.Models;
    using CareerPathFinder.Extensions;

    using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager,
                                SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public class Registration
        {
            public string Username { get; set; }

            public string Password { get; set; }

            public string RepeatPassword { get; set; }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Registration registration)
        {
            if (registration.Password != registration.RepeatPassword)
            {
                return BadRequest("Passwords do not match.");
            }

            if (ModelState.IsValid)
            {
                AppUser newUser = new AppUser
                {
                    UserName = registration.Username
                };

                IdentityResult createResult = await _userManager.CreateAsync(newUser, registration.Password);

                if (createResult.Succeeded)
                {
                    await _signInManager.SignInAsync(newUser, isPersistent: true);
                    return NoContent();
                }

                ModelState.AddIdentityErrors(createResult);
            }

            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByNameAsync(username);

                if (user == null)
                {
                    ModelState.AddModelError("Username", "Username is not registered.");
                }
                else
                {
                    SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, password, isPersistent: true, lockoutOnFailure: false);

                    if (signInResult.Succeeded)
                    {
                        return NoContent();
                    }

                    ModelState.AddModelError("Password", "Incorrect password.");
                }
            }

            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return NoContent();
        }
    }
}