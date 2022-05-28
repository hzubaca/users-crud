using AutoMapper;
using MediatR;
using Users.Application.Contracts;

namespace Users.Application.Features.Queries
{
    public class GetUserPermissionsQueryHandler : IRequestHandler<GetUserPermissionsQuery, PermissionDto>
    {
        private readonly IUserPermissionRepository _userPermissionRepository;
        private readonly IMapper _mapper;

        public GetUserPermissionsQueryHandler(IUserPermissionRepository userPermissionRepository, IMapper mapper)
        {
            _userPermissionRepository = userPermissionRepository;
            _mapper = mapper;
        }

        public async Task<PermissionDto> Handle(GetUserPermissionsQuery request, CancellationToken cancellationToken)
        {
            var permissions = await _userPermissionRepository.GetByUserIdAsync(request.Id);

            return new PermissionDto
            {
                UserId = request.Id,
                PermissionIds = permissions.Select(x => x.PermissionId)
            };
        }
    }
}
