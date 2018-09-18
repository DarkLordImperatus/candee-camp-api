using CGen.Core.Domain.DomainObjects;
using Microsoft.EntityFrameworkCore;

namespace CGen.Core.Repository.Context
{
    public class CGenContext : DbContext
    {
        public CGenContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}