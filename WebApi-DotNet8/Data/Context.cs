using Microsoft.EntityFrameworkCore;
using System.Net;
using WebApi_DotNet8.Entities;

namespace WebApi_DotNet8.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) 
        { 

        }

        public DbSet<AddressTypes> AddressTypes { get; set; }
        public DbSet<CAddresses> CAddresses { get; set; }
        public DbSet<Customers> Customers { get; set; }

    }
}
