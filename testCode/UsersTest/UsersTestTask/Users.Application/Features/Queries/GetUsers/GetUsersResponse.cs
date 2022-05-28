using Users.Domain.Common;

namespace Users.Application.Features.Queries
{
    public class GetUsersResponse
    {
        public IEnumerable<UserDto> Users { get; set; }

        public Paging Paging { get; set; }
    }
}
