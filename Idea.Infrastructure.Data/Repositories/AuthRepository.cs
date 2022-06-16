using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using Idea.Domain.Context;
using Idea.Domain.IdentityModels;
using Idea.Domain.Migrations;
using Idea.Domain.Models;
using Idea.Infrastructure.Data.Helpers;
using Idea.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Idea.Infrastructure.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ISendEmailRepository _sendEmailRepository;
        private readonly IEmailTemplatesRepository _emailTemplatesRepository;
        private readonly ISettingsRepository _settingsRepository;
        private readonly IdeaDbContext _context;




        public AuthRepository(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ISendEmailRepository sendEmailRepository,
            IEmailTemplatesRepository emailTemplatesRepository,
            ISettingsRepository settingsRepository,
            RoleManager<IdentityRole> roleManager,
            IdeaDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _sendEmailRepository = sendEmailRepository;
            _settingsRepository = settingsRepository;
            _emailTemplatesRepository = emailTemplatesRepository;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<ApplicationUser> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, password, false);

            if (result.Succeeded)
                return user;

            return null;
        }


        public async Task<ApplicationUser> SocialLogin(ApplicationUser user)
        {
            var applicationUser = await _userManager.FindByNameAsync(user.UserName);

            if (applicationUser == null)
            {
                await _userManager.CreateAsync(user);
                await _signInManager.SignInAsync(user, false);
                return user;
            }
            else
            {
                await _signInManager.SignInAsync(applicationUser, false);
                return applicationUser;
            }
        }

        public async Task<ApplicationUser> Register(ApplicationUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);

            var hasRole = await _userManager.GetRolesAsync(user);
            if (hasRole.Count == 0)
            {
                string roleName = "Admin";
                IdentityRole addRole = new IdentityRole();
                addRole.Name = roleName;
                addRole.ConcurrencyStamp = roleName;
                await _context.Roles.AddAsync(addRole);
                await _roleManager.CreateAsync(addRole);
                await _userManager.AddToRoleAsync(user, addRole.Name);
            }

            string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var encodedCode = Base64UrlEncoder.Encode(code);

            await SendEmailConfirmation(encodedCode, user.UserName);

            if (result.Succeeded)
            {
                return user;
            }

            return null;
        }

        public async Task<bool> ResendConfirmationEmail(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var encodedCode = Base64UrlEncoder.Encode(code);

            var result = await SendEmailConfirmation(encodedCode, user.UserName);

            return result;
        }

        private async Task<bool> SendEmailConfirmation(string encodedCode, string email)
        {
            var emailTemplate = await _emailTemplatesRepository.GetEmailTemplate(name: DataConstants.EmailTemplates.ConfirmEmail);

            string apiBaseUrl = await _settingsRepository.GetSettingsByKey(DataConstants.Settings.ApiBaseUrl);

            if (emailTemplate != null)
            {
                string link = $"{apiBaseUrl}/api/auth/VerifyEmail/{ email }/?code={ encodedCode }";

                emailTemplate.Body = emailTemplate.Body.Replace("{{LINK}}", link);

                var result = _sendEmailRepository.SendEmail(emailTemplate, email);
                return result;
            }

            return false;
        }

        public async Task<bool> CheckUserExistsByEmail(string email)
        {
            var user = await _userManager.FindByNameAsync(email);

            if (user != null)
                return true;

            return false;
        }

        public async Task<string> VerifyEmail(string username, string code)
        {
            var user = await _userManager.FindByNameAsync(username);
            var url = await _settingsRepository.GetSettingsByKey(DataConstants.Settings.ClientBaseUrl);

            if (user != null)
            {
                var decodedCode = Base64UrlEncoder.Decode(code);
                var result = await _userManager.ConfirmEmailAsync(user, decodedCode);
                if (result.Succeeded)

                    return url + "/login-register?emailConfirmed=true";
            }

            return "";
        }

        public async Task<ApplicationUser> ForgotPassword(string email)
        {
            var user = await _userManager.FindByNameAsync(email);

            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                token = HttpUtility.UrlEncode(token);

                await SendResetPasswordEmail(email, token);
            }

            return user;
        }

        private async Task<bool> SendResetPasswordEmail(string email, string token)
        {

            var emailTemplate = await _emailTemplatesRepository.GetEmailTemplate(name: DataConstants.EmailTemplates.ResetPassword);

            string clientBaseUrl = await _settingsRepository.GetSettingsByKey(DataConstants.Settings.ClientBaseUrl);

            if (emailTemplate != null)
            {
                string resetLink = $"{clientBaseUrl}/reset-password?&token=" + token;

                emailTemplate.Body = emailTemplate.Body.Replace("{{LINK}}", resetLink);
                var result = _sendEmailRepository.SendEmail(emailTemplate, email);

                return result;
            }

            return false;
        }


        public async Task<ApplicationUser> ResetPassword(string email, string token, string password)
        {
            var user = await _userManager.FindByNameAsync(email);
            if (user != null)
            {
                var result = await _userManager.ResetPasswordAsync(user, token, password);
                if (result.Succeeded)
                {
                    return user;
                }
                foreach (var error in result.Errors)
                {
                    return null;
                }
            }

            return user;
        }

        public async Task<string> GenerateJWToken(ApplicationUser user)
        {
            var Claims = new List<Claim>();
            string roles = null;
            try
            {
                var getRole = await _userManager.GetRolesAsync(user);

                foreach (var role in getRole)
                {
                    roles = role;
                }
            }
            catch { }

            var tokenHandler = new JwtSecurityTokenHandler();

            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                    .AddJsonFile(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/appsettings.json").Build();

            var key = Encoding.ASCII.GetBytes(configuration.GetSection("AppSettings:Token").Value);

            var tokenString = "";

            try
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {

                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.FirstName + ' ' + user.LastName),
                        new Claim(DataConstants.Auth.Username, user.UserName),
                        new Claim(DataConstants.Auth.UserId, user.Id.ToString()),
                        new Claim(DataConstants.Auth.EmailConfirmed, user.EmailConfirmed.ToString()),
                        new Claim(ClaimTypes.Role, roles == null ? "" : roles)
                    }),

                    Expires = DateTime.Now.AddHours(12),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha512Signature)

                };


                var token = tokenHandler.CreateToken(tokenDescriptor);

                tokenString = tokenHandler.WriteToken(token);
            }

            catch
            {
                throw new Exception("You need to login first!");
            }

            return tokenString;
        }

        public async Task<ApplicationUser> ForgotPasswordConfirm(string email)
        {
            await ForgotPassword(email);
            var user = await _userManager.FindByNameAsync(email);

            return user;
        }

        public async Task<IEnumerable<UserTypes>> GetUserTypes()
        {
            var userTypes = await _context.UserTypes.ToListAsync();
            return userTypes;
        }

        public async Task<ApplicationUser> RegisterUserDetails(ApplicationUser user)
        {
            await _userManager.UpdateAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
