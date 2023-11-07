using AutoMapper;
using FullStackAuth_WebAPI.ActionFilters;
using FullStackAuth_WebAPI.Contracts;
using FullStackAuth_WebAPI.DataTransferObjects;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IAuthenticationManager _authManager;
        public AuthenticationController(IMapper mapper, UserManager<User> userManager, IAuthenticationManager authManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _authManager = authManager;
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            var user = _mapper.Map<User>(userForRegistration);

            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            // Default role
            var role = "USER";

            // Check if the registered user should be an admin based on the email domain
            if (user.Email.EndsWith("@Admin.com"))
            {
                role = "ADMIN";
            }

            await _userManager.AddToRoleAsync(user, role);

            UserForDisplayDto createdUser = new UserForDisplayDto
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
            return StatusCode(201, createdUser);
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _authManager.ValidateUser(user))
            {
                return Unauthorized();
            }

            var loggedInUser = await _userManager.FindByNameAsync(user.UserName);

            if (loggedInUser != null)
            {
                // Check the user's role
                var userRoles = await _userManager.GetRolesAsync(loggedInUser);

                // Default role
                var role = "USER";

                // Check if the user has the "Admin" role
                if (userRoles.Contains("Admin"))
                {
                    role = "Admin";
                }

                // Create token for the user
                var token = await _authManager.CreateToken();

                return Ok(new { access = token, role });
            }

            return Unauthorized();
        }
    }
}