using Users.Domain.Entities;

namespace Users.Application.Contracts
{
    public interface IUserPermissionRepository : IBaseRepository<UserPermission>
    {
        Task<IEnumerable<UserPermission>> GetByUserIdAsync(int userId);

        Task AddMultipleAsync(IEnumerable<UserPermission> entities);

        Task DeleteMultipleAsync(IEnumerable<UserPermission> entities);
    }
}
