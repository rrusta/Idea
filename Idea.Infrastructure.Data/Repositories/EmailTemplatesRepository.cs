using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Idea.Domain.Context;
using Idea.Domain.DTOs.InsertDTOs;
using Idea.Domain.IdentityModels;
using Idea.Domain.Models;
using Idea.Infrastructure.Data.Helpers;
using Idea.Infrastructure.Data.Interfaces;
using System.Text;

namespace RealEstate.Infrastructure.Data.Repositories
{
    public class EmailTemplatesRepository : IEmailTemplatesRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IdeaDbContext _ctx;
        private readonly ISendEmailRepository _sendEmailRepository;
        private readonly RoleManager<IdentityRole> _roleManager;


        public EmailTemplatesRepository(IdeaDbContext ctx, UserManager<ApplicationUser> userManager,
           ISendEmailRepository sendEmailRepository, RoleManager<IdentityRole> roleManager)
        {
            _ctx = ctx;
            _userManager = userManager;
            _sendEmailRepository = sendEmailRepository;
            _roleManager = roleManager;
        }
        public async Task<string> GetSettingsByKey(string key)
        {
            var value = await _ctx.Settings
            .Where(x => x.Key == key)
            .Select(x => x.Value)
            .FirstOrDefaultAsync();
            return value;
        }
        public async Task<EmailTemplates> GetEmailTemplate(string name)
        {
            var emailTemplate = await _ctx.EmailTemplates.Where(x => x.Name == name).FirstOrDefaultAsync();

            return emailTemplate;
        }


        //this is sending email from view-publication
        public async Task<bool> SendUserMessageEmail(UserMessageEmail userMessageEmail)
        {
            var emailTemplate = await GetEmailTemplate(name: DataConstants.EmailTemplates.SendUserMessageEmail);

            string clientBaseUrl = await GetSettingsByKey(DataConstants.Settings.ClientBaseUrl);

            if (emailTemplate != null)
            {
                string link = $"{clientBaseUrl}/view-publication/{userMessageEmail.PublicationId}";

                emailTemplate.Body = emailTemplate.Body.Replace("{{EMAIL}}", userMessageEmail.FromEmail)
                    .Replace("{{PHONENUMBER}}", userMessageEmail.PhoneNumber)
                    .Replace("{{MESSAGE}}", userMessageEmail.Message)
                    .Replace("{{LINK}}", link);

                var result = _sendEmailRepository.SendEmail(emailTemplate, userMessageEmail.ToEmail);

                return result;
            }

            return false;
        }

        public async Task<bool> SendApprovePublicationEmail(string email)
        {
            var emailTemplate = await GetEmailTemplate(name: DataConstants.EmailTemplates.ApprovePublication);

            string clientBaseUrl = await GetSettingsByKey(DataConstants.Settings.ClientBaseUrl);

            if (emailTemplate != null)
            {
                string link = $"{clientBaseUrl}/publications-list";
                emailTemplate.Body = emailTemplate.Body.Replace("{{LINK}}", link);

                var result = _sendEmailRepository.SendEmail(emailTemplate, email);
                return result;
            }

            return false;
        }

        public async Task<bool> SendPublicationAddedEmail(int publicationId)
        {
            var role = await _roleManager.FindByNameAsync(DataConstants.AspNetRoles.Admin);
            var userRoles = await _ctx.UserRoles.Where(x => x.RoleId == role.Id).ToListAsync();

            var emailTemplate = await GetEmailTemplate(name: DataConstants.EmailTemplates.PublicationAdded);

            string clientBaseUrl = await GetSettingsByKey(DataConstants.Settings.ClientBaseUrl);

            if (emailTemplate != null)
            {
                string link = $"{clientBaseUrl}/confirm-view-publication/{publicationId}";
                emailTemplate.Body = emailTemplate.Body.Replace("{{LINK}}", link);

                foreach (var uRoles in userRoles)
                {
                    var userAdmin = await _userManager.FindByIdAsync(uRoles.UserId);

                    var result = await _sendEmailRepository.SendEmailAsync(emailTemplate, userAdmin.Email);
                }
            }
            return false;
        }

        public async Task<bool> SendPublicationEditedEmail(int publicationId)
        {
            var role = await _roleManager.FindByNameAsync(DataConstants.AspNetRoles.Admin);
            var userRoles = await _ctx.UserRoles.Where(x => x.RoleId == role.Id).ToListAsync();

            var emailTemplate = await GetEmailTemplate(name: DataConstants.EmailTemplates.PublicationEdited);

            string clientBaseUrl = await GetSettingsByKey(DataConstants.Settings.ClientBaseUrl);

            if (emailTemplate != null)
            {
                string link = $"{clientBaseUrl}/confirm-view-publication/{publicationId}";
                emailTemplate.Body = emailTemplate.Body.Replace("{{LINK}}", link);
                foreach (var uRoles in userRoles)
                {
                    var userAdmin = await _userManager.FindByIdAsync(uRoles.UserId);
                    var result = await _sendEmailRepository.SendEmailAsync(emailTemplate, userAdmin.Email);
                }

            }
            return false;
        }

        public async Task<bool> SendRejectPublicationEmail(string email, int publicationId)
        {
            var emailTemplate = await GetEmailTemplate(name: DataConstants.EmailTemplates.RejectPublication);

            string clientBaseUrl = await GetSettingsByKey(DataConstants.Settings.ClientBaseUrl);

            var publicationRejectionReasons = await (from prr in _ctx.PublicationRejectionReasons
                                                     join rr in _ctx.RejectionReasons on prr.RejectionReasonId equals rr.RejectionReasonId
                                                     where prr.PublicationId == publicationId
                                                     select rr).ToListAsync();

            StringBuilder sb = new StringBuilder();

            foreach (var item in publicationRejectionReasons)
            {
                sb.Append(item.Description+ ", ");
            }

            if (emailTemplate != null)
            {
                string link = $"{clientBaseUrl}/edit-publication/{publicationId}";
                emailTemplate.Body = emailTemplate.Body.Replace("{{LINK}}", link)
                .Replace("{{REJECTIONREASONS}}", sb.ToString().Substring(0, sb.ToString().Length - 2));

                var result = _sendEmailRepository.SendEmail(emailTemplate, email);
                return result;
            }

            return false;
        }

        public async Task<bool> SendChangeEmailConfirmation(string id, string encodedCode, string email)
        {
            var emailTemplate = await GetEmailTemplate(name: DataConstants.EmailTemplates.ChangeEmailConfirmation);

            string apiBaseUrl = await GetSettingsByKey(DataConstants.Settings.ApiBaseUrl);

            if (emailTemplate != null)
            {
                string link = $"{apiBaseUrl}/api/settings/verifyEmail/{ email }/{ id }/?code={ encodedCode }";

                emailTemplate.Body = emailTemplate.Body.Replace("{{LINK}}", link);

                var result = _sendEmailRepository.SendEmail(emailTemplate, email);
                return result;
            }

            return false;
        }
    }
}
