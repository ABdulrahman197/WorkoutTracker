using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Core.CreateToken;
using WorkoutTracker.Core.Entites;
using WorkoutTracker.Dtos.Account;

namespace WorkoutTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IToken _token;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IToken token)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _token = token;
        }



        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded) return Unauthorized();

            return Ok(new UserDto()
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                Email = model.Email,
                token = await _token.CreateTokenAsync(user, _userManager),
                height_cm = user.height_cm,
                weight_kg = user.weight_kg

            });
        }


        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto RegistrationForm)
        {
            var NewUser = new ApplicationUser()
            {
                Email = RegistrationForm.Email,
                DisplayName = RegistrationForm.DisplayName,
                UserName = RegistrationForm.Email.Split("@")[0],
                PhoneNumber = RegistrationForm.PhoneNumber,
                height_cm = RegistrationForm.height_cm , 
                weight_kg= RegistrationForm.weight_kg 
            };


            var result = await _userManager.CreateAsync(NewUser, RegistrationForm.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors); // Return errors to help debugging


            return Ok(new UserDto()
            {
                DisplayName = RegistrationForm.DisplayName,
                Email = RegistrationForm.Email,
                token = await _token.CreateTokenAsync(NewUser, _userManager), 
                height_cm = RegistrationForm.height_cm,
                weight_kg = RegistrationForm.weight_kg
            });

        }


    }
}
