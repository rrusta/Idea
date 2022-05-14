using RealEstate.Application.DTOViewModels.InsertDTOViewModels;
using RealEstate.Application.DTOViewModels.UpdateDTOViewModels;
using RealEstate.Application.ViewModels;
using RealEstate.Domain.IdentityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Interfaces
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
