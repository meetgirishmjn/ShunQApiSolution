using BusinessCore.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCore.Services.Contracts
{
   public interface IEmailGateway
    {
        Task<MailSendResult> SendMail(string to, string subject, string body);
    }
}
