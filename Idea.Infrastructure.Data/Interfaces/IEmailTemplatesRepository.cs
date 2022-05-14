using Idea.Domain.DTOs.InsertDTOs;
using Idea.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Idea.Infrastructure.Data.Interfaces
{
    public interface IEmailTemplatesRepository
    {
        public Task<EmailTemplates> GetEmailTemplate(string name);

        public Task<bool> SendUserMessageEmail(UserMessageEmail userMessageEmail);

        public Task<bool> SendApprovePublicationEmail(string email);

        public Task<bool> SendPublicationAddedEmail(int publicationId);

        public Task<bool> SendPublicationEditedEmail(int publicationId);

        public Task<bool> SendRejectPublicationEmail(string email, int publicationId);

        public Task<bool> SendChangeEmailConfirmation(string id,string encodedCode, string newEmail);
    }
}
