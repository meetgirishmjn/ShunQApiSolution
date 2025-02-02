﻿using BusinessCore.DataAccess;
using BusinessCore.DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.DataAccess
{
    public class DataContextManager : IDataContextManager
    {
        public CoreDbContext Context { get; set; }

        public DataContextManager(CoreDbContext context)
        {
            this.Context = context;
        }

        public CoreDbContext GetContext()
        {
            return Context;
        }
    }
}
