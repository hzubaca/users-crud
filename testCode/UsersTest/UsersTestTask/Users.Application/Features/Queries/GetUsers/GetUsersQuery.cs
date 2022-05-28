using MediatR;
using Users.Domain.Common;
using Users.Domain.Enums;

namespace Users.Application.Features.Queries
{
    public class GetUsersQuery : IRequest<GetUsersResponse>
    {
        public SearchType? SearchType { get; set; }

        public string? SearchValue { get; set; }

        public Paging? Paging { get; set; }
    }
}
