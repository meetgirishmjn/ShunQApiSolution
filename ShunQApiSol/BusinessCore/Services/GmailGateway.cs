using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using BusinessCore.AppHandlers.Contracts;
using BusinessCore.Services.Contracts;
using BusinessCore.Services.Models;

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
                using (var client = new SmtpClient("in-v3.mailjet.com"))
                {

                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("83ca57e7fe4276b4c774aba98008ec63", "0f084858b779085d4e9fa365d17934ff");
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
