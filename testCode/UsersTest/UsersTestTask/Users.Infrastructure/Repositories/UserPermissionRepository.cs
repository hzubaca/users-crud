using Users.Application.Contracts;
using Users.Domain.Entities;
using Users.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Users.Infrastructure.Repositories
{
    public class UserPermissionRepository : BaseRepository<UserPermission>, IUserPermissionRepository
    {
        public UserPermissionRepository(UsersContext usersContext) : base(usersContext)
        {
        }

        public async Task<IEnumerable<UserPermission>> GetByUserIdAsync(int userId)
        {
            return await _dbContext.UserPermission.Include(x => x.Permission)
                                                  .Where(userPerm => userPerm.UserId == userId && userPerm.Permission.IsActive)
                                                  .ToListAsync();
        }

        public async Task AddMultipleAsync(IEnumerable<UserPermission> entities)
        {
            _dbContext.UserPermission.AddRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteMultipleAsync(IEnumerable<UserPermission> entities)
        {
            _dbContext.UserPermission.RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
        }
    }
}
