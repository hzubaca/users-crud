using Users.Application.Contracts;
using Users.Domain.Entities;
using Users.Infrastructure.Persistance;

namespace Users.Infrastructure.Repositories
{
    public class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(UsersContext usersContext) : base(usersContext)
        {
        }
    }
}
