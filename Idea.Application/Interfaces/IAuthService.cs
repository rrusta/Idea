namespace RealEstate.Application.Interfaces
{
    using Microsoft.AspNetCore.Mvc;
    using RealEstate.Application.ViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAuthService
    {
        Task<UserViewModel> Register(RegisterUserViewModel registerViewModel);

        Task<UserViewModel> Login(LoginViewModel loginViewModel);

        Task<UserViewModel> SocialLogin(SocialUserViewModel socialUsersViewModel);

        Task<string> GenerateJWToken(UserViewModel user);

        Task<bool> CheckUserExistsByEmail(string email);


        Task<UserViewModel> ForgotPassword(ForgotPasswordViewModel forgetPasswordViewModel);

        Task<UserViewModel> ResetPassword(ResetPasswordViewModel resetPasswordViewModel);

        Task<string> VerifyEmail(string username, string code);

        public Task<UserViewModel> ForgotPasswordConfirm(ForgotPasswordViewModel forgotPasswordViewModel);

        public Task<bool> ResendConfirmationEmail(string email);

        public Task<IEnumerable<UserTypesViewModel>> GetUserTypes();

        public Task<UserViewModel> RegisterUserDetails(RegisterUserDetailsViewModel registerUserDetailsViewModel); 
    }
}
