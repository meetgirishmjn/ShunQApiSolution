using BusinessCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.DataAccess.Contracts
{
   public interface IDataContextable
    {
        UserIdentity CurrentUser { get; set; }
        IDataContextManager ContextManager { get; set; }
    }
}
