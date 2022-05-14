using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RealEstate.Application.DTOViewModels.InsertDTOViewModels;
using RealEstate.Application.Interfaces;
using RealEstate.Application.ViewModels;
using RealEstate.Domain.DTOs.InsertDTOs;
using RealEstate.Domain.IdentityModels;
using RealEstate.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Services
{
    public class EmailTemplatesService : IEmailTemplatesService
    {
        private readonly IEmailTemplatesRepository _emailTemplatesRepository;
        private readonly ISettingsRepository _settingsRepository;

        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public EmailTemplatesService(IEmailTemplatesRepository emailTemplatesRepository , ISettingsRepository settingsRepository, 
            IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _emailTemplatesRepository = emailTemplatesRepository;
            _settingsRepository = settingsRepository;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<bool> SendUserMessageEmail(UserMessageEmailViewModel userMessageEmailView)
        {
            var userEmailMessage = _mapper.Map<UserMessageEmail>(userMessageEmailView);
            return await _emailTemplatesRepository.SendUserMessageEmail(userEmailMessage); 

        }

        public async Task<bool> SendApprovePublicationEmail(string createdBy)
        {
            var user = await _userManager.FindByIdAsync(createdBy);
            return await _emailTemplatesRepository.SendApprovePublicationEmail(user.UserName);
        }

        public async Task<bool> SendRejectPublicationEmail(string createdBy, int publicationId)
        {
            var user = await _userManager.FindByIdAsync(createdBy);
            return await _emailTemplatesRepository.SendRejectPublicationEmail(user.UserName, publicationId);
        }

        public async Task<bool> SendPublicationAddedEmail(int publicationId)
        {
            return await _emailTemplatesRepository.SendPublicationAddedEmail(publicationId);
        }

        public async Task<bool> SendPublicationEditedEmail(int publicationId)
        {
            return await _emailTemplatesRepository.SendPublicationEditedEmail(publicationId);
        }

        
        public async Task<UserViewModel> ChangeEmail(ChangeEmailViewModel changeEmailViewModel)
        {
            var user = await _settingsRepository.ChangeEmail(id: changeEmailViewModel.Id, email: changeEmailViewModel.Email, newEmail: changeEmailViewModel.NewEmail);
            return _mapper.Map<UserViewModel>(user);
        }

    }
}
