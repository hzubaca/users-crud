using Users.Domain.Common;
using Users.Domain.Entities;
using Users.Domain.Enums;

namespace Users.Application.Contracts
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<List<User>> SearchUsers(SearchType? searchType, string? searchValue, Paging paging);
    }
}
