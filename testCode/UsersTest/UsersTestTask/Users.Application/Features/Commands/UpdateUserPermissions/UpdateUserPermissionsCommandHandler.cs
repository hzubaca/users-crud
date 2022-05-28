using MediatR;
using Microsoft.Extensions.Logging;
using Users.Application.Contracts;
using Users.Domain.Entities;

namespace Users.Application.Features.Commands
{
    public class UpdateUserPermissionsCommandHandler : IRequestHandler<UpdateUserPermissionsCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserPermissionRepository _userPermissionRepository;
        private readonly ILogger<UpdateUserPermissionsCommandHandler> _logger;

        public UpdateUserPermissionsCommandHandler(IUserRepository userRepository, IUserPermissionRepository userPermissionRepository, ILogger<UpdateUserPermissionsCommandHandler> logger)
        {
            _userRepository = userRepository;
            _userPermissionRepository = userPermissionRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateUserPermissionsCommand request, CancellationToken cancellationToken)
        {
            var dbUser = await _userRepository.GetByIdAsync(request.UserId);

            if (dbUser == null)
            {
                throw new ArgumentException($"User with id {request.UserId} could not be found!");
            }

            var dbUserPermissions = await _userPermissionRepository.GetByUserIdAsync(request.UserId);

            var addUserPermissionsIds = request.PermissionIds.Where(newPerm => dbUserPermissions.All(userPerm => userPerm.PermissionId != newPerm));
            var removeUserPermissions = dbUserPermissions.Where(userPerm => request.PermissionIds.All(newPerm => newPerm != userPerm.PermissionId));

            if (addUserPermissionsIds.Any())
            {
                await _userPermissionRepository.AddMultipleAsync(request.PermissionIds.Select(permissionId => new UserPermission { PermissionId = permissionId, UserId = request.UserId }));
            }

            if (removeUserPermissions.Any())
            {
                await _userPermissionRepository.DeleteMultipleAsync(removeUserPermissions);
            }

            return Unit.Value;
        }
    }
}
