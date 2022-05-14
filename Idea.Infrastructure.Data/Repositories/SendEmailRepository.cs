using Idea.Domain.Context;
using Idea.Domain.Models;
using Idea.Infrastructure.Data.Helpers;
using Idea.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Data.Repositories
{
    public class SendEmailRepository : ISendEmailRepository
    {
        private readonly IOperatorSettingsRepository _operatorSettingsRepository;

        public SendEmailRepository(IOperatorSettingsRepository operatorSettingsRepository)
        {
            _operatorSettingsRepository = operatorSettingsRepository;
        }
        public bool SendEmail(EmailTemplates email, string emailTo)
        {
            try
            {
                var operatorSettings = _operatorSettingsRepository.GetOperatorSettings(description:DataConstants.EmailTemplates.SendEmail);
                if (operatorSettings == null)
                    return false;

                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(operatorSettings.Email);
                mail.To.Add(emailTo);
                mail.Subject =email.Subject;
                mail.Body = email.Body;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient(operatorSettings.Smtp, operatorSettings.Port);

                smtp.Credentials = new NetworkCredential(operatorSettings.Email, operatorSettings.Password);
                //smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.SendMailAsync(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> SendEmailAsync(EmailTemplates email, string emailTo)
        {
            try
            {
                var operatorSettings =await _operatorSettingsRepository.GetOperatorSettingsAsync(description: DataConstants.EmailTemplates.SendEmail);
                if (operatorSettings == null)
                    return false;

                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(operatorSettings.Email);
                mail.To.Add(emailTo);
                mail.Subject = email.Subject;
                mail.Body = email.Body;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient(operatorSettings.Smtp, operatorSettings.Port);

                smtp.Credentials = new NetworkCredential(operatorSettings.Email, operatorSettings.Password);
                //smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
