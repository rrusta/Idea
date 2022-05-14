using Idea.Domain.DTOs.UpdateDTOs;
using Idea.Domain.IdentityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Idea.Infrastructure.Data.Interfaces
{
    public interface ISettingsRepository
    {
        Task<string> GetSettingsByKey(string key);

        public Task<ApplicationUser> ChangePassword(string username, string currentPassword, string newPassword, string confirmPassword);

        public Task<ApplicationUser> EditProfile(string email, string FirstName, string LastName, int UserTypeId);

        public Task<ApplicationUser> GetProfile(string username);

        public Task<string> VerifyEmail(string id, string newEmail, string code);

        public Task<ApplicationUser> UpdateProfilePicture(UpdateProfilePicture updateProfilePicture);

        public Task<ApplicationUser> DeleteProfilePicture(string email);

        public Task<ApplicationUser> ChangeEmail(string id, string email, string newEmail);
    }
}
