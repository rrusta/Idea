using Idea.Application.DTOViewModels.InsertDTOViewModels;
using Idea.Application.ViewModels;
using RealEstate.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Idea.Application.Interfaces
{
    public interface IEmailTemplatesService
    {
        public Task<bool> SendUserMessageEmail(UserMessageEmailViewModel userMessageEmailView);

        public Task<bool> SendApprovePublicationEmail(string createdBy);

        public Task<bool> SendPublicationAddedEmail(int publicationId);

        public Task<bool> SendPublicationEditedEmail(int publicationId);

        public Task<bool> SendRejectPublicationEmail(string createdBy, int publicationId);

        Task<UserViewModel> ChangeEmail(ChangeEmailViewModel changeEmailViewModel);
    }
}
