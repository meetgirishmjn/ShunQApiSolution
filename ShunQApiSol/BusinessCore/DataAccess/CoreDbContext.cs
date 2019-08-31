using BusinessCore.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.DataAccess
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        { }

        public DbSet<UserMaster> UserMasters { get; set; }
        public DbSet<LogInSession> LogInSessions { get; set; }
    }

}
