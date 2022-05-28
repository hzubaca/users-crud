using AutoMapper;
using MediatR;
using Users.Application.Contracts;

namespace Users.Application.Features.Queries
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, GetUsersResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUsersResponse> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var paging = request.Paging;

            if (paging == null)
            {
                paging = new Domain.Common.Paging
                {
                    CurrentPage = 1,
                    PageSize = 10
                };
            }

            var users = await _userRepository.SearchUsers(request.SearchType, request.SearchValue?.ToLower(), paging);

            return new GetUsersResponse
            {
                Users = users?.Select(user => _mapper.Map<UserDto>(user)) ?? new List<UserDto>(),
                Paging = paging
            };
        }
    }
}
