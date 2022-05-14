using Idea.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Idea.Infrastructure.Data.Interfaces
{
    public interface ISendEmailRepository
    {
        bool SendEmail(EmailTemplates email, string emailTo);
        Task<bool> SendEmailAsync(EmailTemplates email, string emailTo);
    }
}
