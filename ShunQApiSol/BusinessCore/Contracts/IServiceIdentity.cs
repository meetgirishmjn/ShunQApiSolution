using BusinessCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.Contracts
{
   public interface IServiceIdentity
    {
        User CurrentUser { get; set; }
    }
}
