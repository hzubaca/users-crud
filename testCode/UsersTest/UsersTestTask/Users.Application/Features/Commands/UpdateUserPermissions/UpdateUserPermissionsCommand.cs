using MediatR;

namespace Users.Application.Features.Commands
{
    public class UpdateUserPermissionsCommand : IRequest
    {
        public int UserId { get; set; }

        public List<int> PermissionIds { get; set; }
    }
}
