using Users.Application.Contracts;
using Users.Domain.Common;
using Users.Domain.Entities;
using Users.Domain.Enums;
using Users.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Users.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(UsersContext usersContext) : base(usersContext)
        {
        }

        public Task<List<User>> SearchUsers(SearchType? searchType, string? searchValue, Paging paging)
        {
            var result = _dbContext.User.Include(user => user.Status)
                                        .Where(user => ((searchType == SearchType.Undefined)
                                                    || (searchType == SearchType.FirstName && user.FirstName.ToLower().Contains(searchValue))
                                                    || (searchType == SearchType.LastName && user.LastName.ToLower().Contains(searchValue))
                                                    || (searchType == SearchType.Username && user.Username.ToLower().Contains(searchValue))
                                                    || (searchType == SearchType.Email && user.Email.ToLower().Contains(searchValue))
                                                    || (searchType == SearchType.Status && user.Status.Name == searchValue))
                                                    && !user.IsDeleted)
                                        //.Skip((paging.CurrentPage - 1) * paging.PageSize)
                                        //.Take(paging.PageSize)
                                        .ToListAsync();

            return result;
        }

        public async override Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.User.Include(user => user.Status)
                                        .SingleOrDefaultAsync(user => user.Id == id);
        }
    }
}
