using Microsoft.EntityFrameworkCore;
using Users.Domain.Entities;

namespace Users.Infrastructure.Persistance
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options) : base(options) { }

        public DbSet<User> User { get; set; }

        public DbSet<Permission> Permission { get; set; }

        public DbSet<Status> Status { get; set; }

        public DbSet<UserPermission> UserPermission { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
