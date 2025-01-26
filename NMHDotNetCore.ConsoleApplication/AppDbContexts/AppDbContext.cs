using Microsoft.EntityFrameworkCore;
using NMHDotNetCore.ConsoleApplication.BlogModels;
using NMHDotNetCore.ConsoleApplication.ConnectionStrings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMHDotNetCore.ConsoleApplication.AppDbContexts
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogModel> Blogs { get; set; } 
    }
}
