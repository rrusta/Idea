using AutoMapper;
using Idea.Application.DTOViewModels.UpdateDTOViewModels;
using Idea.Application.Interfaces;
using Idea.Application.ViewModels;
using Idea.Domain.DTOs.UpdateDTOs;
using Idea.Infrastructure.Data.Interfaces;

namespace Idea.Application.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly ISettingsRepository _settingsRepository;

        private readonly IMapper _mapper;

        public SettingsService(ISettingsRepository settingsRepository, IMapper mapper)
        {
            _settingsRepository = settingsRepository;
            _mapper = mapper;
        }
        public async Task<UserViewModel> ChangePassword(ChangePasswordViewModel changePasswordViewModel) 
        {
            var user = await _settingsRepository.ChangePassword(username: changePasswordViewModel.Username,currentPassword: changePasswordViewModel.CurrentPassword, newPassword: changePasswordViewModel.NewPassword, confirmPassword: changePasswordViewModel.ConfirmPassword);
            return _mapper.Map<UserViewModel>(user);
        }

        public async Task<UserViewModel> EditProfile(EditProfileViewModel editProfileViewModel)
        {
            var user = await _settingsRepository.EditProfile(email: editProfileViewModel.Email, FirstName: editProfileViewModel.FirstName, LastName: editProfileViewModel.LastName, UserTypeId: editProfileViewModel.UserTypeId);
            return _mapper.Map<UserViewModel>(user);
        }

        public async Task<LoggedProfileViewModel> GetProfile(string username)
        {
            var user = await _settingsRepository.GetProfile(username: username);
            return _mapper.Map<LoggedProfileViewModel>(user); 
        }

        public async Task<string> VerifyEmail(string id, string newEmail, string code)
        {
            return await _settingsRepository.VerifyEmail(id,newEmail, code);
        }
        public async Task<UserViewModel> UpdateProfilePicture(UpdateProfilePictureViewModel updateProfilePictureViewModel)
        {
            var updateProfilePicture = _mapper.Map<UpdateProfilePicture>(updateProfilePictureViewModel);
            
            var user = await _settingsRepository.UpdateProfilePicture(updateProfilePicture);
            return _mapper.Map<UserViewModel>(user);
        }

        public async Task<UserViewModel> DeleteProfilePicture(string email)
        {
            var user = await _settingsRepository.DeleteProfilePicture(email);
            return _mapper.Map<UserViewModel>(user);
        }
    }
}
