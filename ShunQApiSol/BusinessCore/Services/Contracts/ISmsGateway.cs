using BusinessCore.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCore.Services.Contracts
{
    public interface ISmsGateway
    {
        Task<SmsSendResult> SendSms(string mobileNumber, string opt);
    }
}
