using Idea.Domain.IdentityModels;
using Idea.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Idea.Infrastructure.Data.Interfaces
{
    public interface IAuthRepository
    {
        Task<ApplicationUser> Register(ApplicationUser user, string password);

        Task<ApplicationUser> Login(string username, string password);

        Task<ApplicationUser> SocialLogin(ApplicationUser user);

        Task<string> GenerateJWToken(ApplicationUser user);

        Task<bool> CheckUserExistsByEmail(string email);

        Task<ApplicationUser> ForgotPassword(string email);

        Task<ApplicationUser> ResetPassword(string email, string token,string password); 

        Task<string> VerifyEmail(string username, string code);

        public  Task<ApplicationUser> ForgotPasswordConfirm(string email);

        public Task<bool> ResendConfirmationEmail(string email);

        Task<IEnumerable<UserTypes>> GetUserTypes();

        Task<ApplicationUser> RegisterUserDetails(ApplicationUser user); 
    }
}
