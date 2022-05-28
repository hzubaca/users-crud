using MediatR;

namespace Users.Application.Features.Queries
{
    public record GetUserPermissionsQuery(int Id) : IRequest<PermissionDto>;
}
