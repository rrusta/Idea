namespace Idea.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Idea.Application.Interfaces;
    using Idea.Application.ViewModels;
    using System.Threading.Tasks;
    using RealEstate.Application.ViewModels;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserViewModel registerUserViewModel)
        {
            var user = await _authService.Register(registerUserViewModel);

            if (user != null)
            {
                var tokenString = await _authService.GenerateJWToken(user);
                if (tokenString != "")
                {
                    user.TokenString = tokenString;
                    return Ok(user);
                }
            }

            return BadRequest("User cannot be created");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel loginViewModel)
        {
            var user = await _authService.Login(loginViewModel);

            if (user != null)
            {
                var tokenString = await _authService.GenerateJWToken(user);
                if (tokenString != "")
                {
                    user.TokenString = tokenString;
                    return Ok(user);
                }
            }

            return Unauthorized();
        }

        [HttpPost("socialLogin")]
        public async Task<IActionResult> SocialLogin(SocialUserViewModel socialUsersViewModel)
        {
            var user = await _authService.SocialLogin(socialUsersViewModel);

            if (user != null)
            {
                var tokenString = await _authService.GenerateJWToken(user);
                if (tokenString != "")
                {
                    user.TokenString = tokenString;
                    return Ok(user);
                }
            }

            return Unauthorized();
        }

        [Route("verifyEmail/{username}")]
        [HttpGet]
        public async Task<IActionResult> VerifyEmail(string username, string code)
        {
            var verifyEmail = await _authService.VerifyEmail(username: username, code: code);
            if (verifyEmail != "")
                return Redirect(verifyEmail);

            return BadRequest();
        }

        [Route("checkUserExistsByEmail/{email}")]
        [HttpGet]
        public async Task<IActionResult> CheckUserExistsByEmail(string email)
        {
            var userExists = await _authService.CheckUserExistsByEmail(email);
            return Ok(userExists);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordViewModel)
        {
            var user = await _authService.ForgotPassword(forgotPasswordViewModel);
            if (user != null)
            {
                var tokenString = await _authService.GenerateJWToken(user);
                if (tokenString != "")
                {
                    user.TokenString = tokenString;
                    return Ok();
                }
            }
            return Unauthorized();
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody]ResetPasswordViewModel resetPasswordViewModel)
        {

            var user = await _authService.ResetPassword(resetPasswordViewModel);
            if (user != null)
            {
                var tokenString = await _authService.GenerateJWToken(user);
                if (tokenString != "")
                {
                    user.TokenString = tokenString;
                    return Ok();
                }
            }

            return Unauthorized();
        }

        [HttpPost("forgot-password-confirm")]
        public async Task<IActionResult> ForgotPasswordConfirm(ForgotPasswordViewModel forgotPasswordViewModel)
        {
            var user = await _authService.ForgotPasswordConfirm(forgotPasswordViewModel);
            if (user != null)
            {
                var tokenString = await _authService.GenerateJWToken(user);
                if (tokenString != "")
                {
                    user.TokenString = tokenString;
                    return Ok();
                }
            }

            return Unauthorized();
        }

        [HttpPost("resendConfirmationEmail")]
        public async Task<IActionResult> ResendConfirmationEmail([FromBody]string email)
        {

            var resend = await _authService.ResendConfirmationEmail(email);

            return Ok(resend);
        }

        [HttpGet("getUserTypes")]
        public async Task<IActionResult> GetUserTypes()
        {
            var userTypes = await _authService.GetUserTypes();
            return Ok(userTypes);
        }

        [HttpPost("registerUserDetails")]
        public async Task<IActionResult> RegisterUserDetails(RegisterUserDetailsViewModel registerUserDetailsViewModel) 
        {
            var user = await _authService.RegisterUserDetails(registerUserDetailsViewModel);
            if(user != null)
            {
                return Ok(user);
            }
            return BadRequest("User details can not be registered");
        }
    }
}
