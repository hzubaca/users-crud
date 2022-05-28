using Microsoft.EntityFrameworkCore;
using Users.Domain.Entities;

namespace Users.Infrastructure.Persistance
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasIndex(x => x.Username).IsUnique();

            modelBuilder.Entity<Permission>()
                        .HasIndex(x => x.Code).IsUnique();

            modelBuilder.Entity<Status>()
                        .HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<Status>().HasData(
                new Status
                {
                    Id = 1,
                    Name = "Active",
                    Description = "User is active",
                    IsActive = true
                },
                new Status
                {
                    Id = 2,
                    Name = "Inactive",
                    Description = "User is inactive",
                    IsActive = true
                }
            );

            modelBuilder.Entity<Permission>().HasData(
                new Permission
                {
                    Id = 1,
                    Code = "View",
                    Description = "Allows view users list action",
                    IsActive = true
                },
                new Permission
                {
                    Id = 2,
                    Code = "Add",
                    Description = "Allows add user action",
                    IsActive = true
                },
                new Permission
                {
                    Id = 3,
                    Code = "Edit",
                    Description = "Allows edit user action",
                    IsActive = true
                },
                new Permission
                {
                    Id = 4,
                    Code = "Delete",
                    Description = "Allows delete user action",
                    IsActive = true
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Admin",
                    LastName = "Admin",
                    Username = "Admin",
                    Email = "admin@admin.com",
                    Password = "admin",
                    StatusId = 1,
                    IsDeleted = false
                },
                new User
                {
                    Id = 2,
                    FirstName = "Hamza",
                    LastName = "Zubaca",
                    Username = "hzubaca",
                    Email = "hzubaca@gmail.com",
                    Password = "hzubaca!",
                    StatusId = 1,
                    IsDeleted = false
                }
            );

            modelBuilder.Entity<UserPermission>().HasData(
                new UserPermission
                {
                    Id = 1,
                    UserId = 1,
                    PermissionId = 1
                },
                new UserPermission
                {
                    Id = 2,
                    UserId = 1,
                    PermissionId = 2
                },
                new UserPermission
                {
                    Id = 3,
                    UserId = 1,
                    PermissionId = 3
                },
                new UserPermission
                {
                    Id = 4,
                    UserId = 1,
                    PermissionId = 4
                },
                new UserPermission
                {
                    Id = 5,
                    UserId = 2,
                    PermissionId = 1
                }
            );
        }
    }
}
