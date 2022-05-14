namespace Idea.Infrastructure.Data.Repositories
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using Idea.Domain.Context;
    using Idea.Domain.DTOs.InsertDTOs;
    using Idea.Domain.DTOs.UpdateDTOs;
    using Idea.Domain.IdentityModels;
    using Idea.Domain.Models;
    using Idea.Infrastructure.Data.Helpers;
    using Idea.Infrastructure.Data.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;

    public class SettingsRepository : ISettingsRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IdeaDbContext _ctx;
        private readonly IEmailTemplatesRepository _emailTemplatesRepository;
        private readonly IAWSS3Repository _awsS3Repository;

        public SettingsRepository(IdeaDbContext ctx, UserManager<ApplicationUser> userManager,
            IEmailTemplatesRepository emailTemplatesRepository,
            IAWSS3Repository awsS3Repository)
        {
            _ctx = ctx;
            _userManager = userManager;
            _emailTemplatesRepository = emailTemplatesRepository;
            _awsS3Repository = awsS3Repository;
        }

        public async Task<string> GetSettingsByKey(string key)
        {
            var value = await _ctx.Settings
            .Where(x => x.Key == key)
            .Select(x => x.Value)
            .FirstOrDefaultAsync();
            return value;
        }

        public async Task<ApplicationUser> ChangePassword(string username, string currentPassword, string newPassword, string confirmPassword)
        {

            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                var passwordResult = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
                if (passwordResult.Succeeded)
                {
                    return user;
                }
                foreach (var error in passwordResult.Errors)
                {
                    return null;
                }
            }
            return user;
        }

        public async Task<ApplicationUser> EditProfile(string email, string FirstName, string LastName, int UserTypeId)
        {
            var applicationUser = await _userManager.FindByEmailAsync(email);

            applicationUser.Email = email;
            applicationUser.FirstName = FirstName;
            applicationUser.LastName = LastName;
            applicationUser.UserTypeId = UserTypeId;

            var editResult = await _userManager.UpdateAsync(applicationUser);

            if (editResult.Succeeded)
            {
                return applicationUser;
            }
            foreach (var error in editResult.Errors)
            {
                return null;
            }
            return applicationUser;
        }

        public async Task<ApplicationUser> GetProfile(string username)
        {
            var loggedUser = await _userManager.FindByNameAsync(username);
            return loggedUser;
        }

        public async Task<string> VerifyEmail(string id, string newEmail, string code)
        {
            var user = await _userManager.FindByIdAsync(id);
            var url = await GetSettingsByKey(DataConstants.Settings.ClientBaseUrl);

            if (user != null)
            {
                var decodedCode = Base64UrlEncoder.Decode(code);
                var emailResult = await _userManager.ChangeEmailAsync(user, newEmail, decodedCode);
                user.UserName = newEmail;
                user.NormalizedUserName = newEmail;
                await _ctx.SaveChangesAsync();
                if (emailResult.Succeeded)
                {
                    return url;
                }
                foreach (var error in emailResult.Errors)
                {
                    return null;
                }
            }

            return "";
        }

        public async Task<ApplicationUser> UpdateProfilePicture(UpdateProfilePicture updateProfilePicture)
        {
            var user = await _userManager.FindByEmailAsync(updateProfilePicture.Email);
            //if (user.Avatar != null)
            //{
            //    await _cloudinaryRepository.DeleteAttachment(user.Email);
            //}

            var url = await _awsS3Repository.UploadImage(updateProfilePicture.File);

            user.Avatar = url;
            await _ctx.SaveChangesAsync();

            return user;
        }

        public async Task<ApplicationUser> DeleteProfilePicture(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user.Avatar == null)
            {
                return user;
            }
            else
            {
                //await _cloudinaryRepository.DeleteAttachment(user.Avatar);

                user.Avatar = null;
                await _ctx.SaveChangesAsync();
            }
            return user;
        }
        public async Task<ApplicationUser> ChangeEmail(string id, string email, string newEmail)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var code = await _userManager.GenerateChangeEmailTokenAsync(user, newEmail);
                code = Base64UrlEncoder.Encode(code);
                await _emailTemplatesRepository.SendChangeEmailConfirmation(id, code, newEmail);
                return user;
            }
            return null;
        }

    }

}
