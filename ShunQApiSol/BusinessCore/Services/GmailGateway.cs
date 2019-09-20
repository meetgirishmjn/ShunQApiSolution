using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using BusinessCore.Services.Contracts;
using BusinessCore.Services.Models;

namespace BusinessCore.Services
{
    public class GmailGateway : IEmailGateway
    {
        public async Task<MailSendResult> SendMail(string to, string subject, string body)
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
                result.Status = ex.Message;
                result.HasError = true;
            }
            return result;
        }
    }
}
