using MediatR;
using Microsoft.Extensions.Logging;
using Users.Application.Contracts;

namespace Users.Application.Features.Commands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<DeleteUserCommandHandler> _logger;

        public DeleteUserCommandHandler(IUserRepository userRepository, ILogger<DeleteUserCommandHandler> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var dbUser = await _userRepository.GetByIdAsync(request.Id);

            if (dbUser == null)
            {
                throw new ArgumentException($"User with id {request.Id} could not be found!");
            }

            // Doing user soft delete
            dbUser.IsDeleted = true;
            await _userRepository.UpdateAsync(dbUser);

            return Unit.Value;
        }
    }
}
