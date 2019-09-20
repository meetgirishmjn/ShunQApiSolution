using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.Services.Models
{
   public class MailSendResult
    {
        public bool HasError { get; set; }
        public string Status { get; set; }
        public string RefId { get; set; }
    }
}
