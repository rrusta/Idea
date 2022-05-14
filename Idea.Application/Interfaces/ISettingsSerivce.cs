using Idea.Application.DTOViewModels.UpdateDTOViewModels;
using Idea.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Idea.Application.Interfaces
{
    public interface ISettingsService
    {

        public  Task<UserViewModel> ChangePassword(ChangePasswordViewModel changePasswordViewModel);

        public Task<UserViewModel> EditProfile(EditProfileViewModel editProfileViewModel);

        public Task<LoggedProfileViewModel> GetProfile(string username);

        public Task<string> VerifyEmail(string id, string newEmail, string code);

        Task<UserViewModel> UpdateProfilePicture(UpdateProfilePictureViewModel updateProfilePictureViewModel);

        Task<UserViewModel> DeleteProfilePicture(string email);
        
    }
}
