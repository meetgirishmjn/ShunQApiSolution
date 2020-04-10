using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using BusinessCore.AppHandlers.Contracts;
using BusinessCore.Services.Contracts;
using BusinessCore.Services.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BusinessCore.Services
{
    public class GmailGateway : IEmailGateway
    {  
        ILoggerManager  logger;
        public GmailGateway(ILoggerManager logger)
        {
            this.logger = logger;
        }

        public async Task<MailSendResult> SendMail(string to, string subject, string body)
        {
            var result = new MailSendResult();
            try
            {
                const string API_KEY = "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";

                var client = new SendGridClient(API_KEY);

                SendGridMessage mailMessage = new SendGridMessage();
                mailMessage.SetFrom("Shunq.CareServices.v1@gmail.com");
                mailMessage.AddTo(to);
                mailMessage.AddContent(MimeType.Html, body);
                mailMessage.SetSubject(subject);
                var response = await client.SendEmailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                result.Status = ex.Message;
                result.HasError = true;
            }
            return result;
        }

        [Obsolete]
        public async Task<MailSendResult> SendMail_Obsolete(string to, string subject, string body)
        {
            var result = new MailSendResult();
            try
            {
                using (var client = new SmtpClient("smtp.gmail.com"))
                {

                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("Shunq.CareServices.v1@gmail.com", "shunq@V12019");
                    client.EnableSsl = true;
                    client.Port = 587;
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("Shunq.CareServices.v1@gmail.com");
                    mailMessage.To.Add(to);
                    mailMessage.Body = body;
                    mailMessage.Subject = subject;
                    mailMessage.IsBodyHtml = true;
                    await client.SendMailAsync(mailMessage);
                    result.HasError = false;
                }
            }
            catch (Exception ex)
            {
                logger.LogError("SendMail Exception: " + ex.Message);
                result.Status = ex.Message;
                result.HasError = true;
            }
            return result;
        }
    }
}
