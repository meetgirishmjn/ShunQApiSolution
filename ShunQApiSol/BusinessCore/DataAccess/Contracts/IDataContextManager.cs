using BusinessCore.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.DataAccess.Contracts
{
    public interface IDataContextManager
    {
        CoreDbContext GetContext();
    }
}
