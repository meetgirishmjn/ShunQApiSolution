using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.Contracts
{
   public interface IDataContextable
    {
        IDataContextManager ContextManager { get; set; }
    }
}
