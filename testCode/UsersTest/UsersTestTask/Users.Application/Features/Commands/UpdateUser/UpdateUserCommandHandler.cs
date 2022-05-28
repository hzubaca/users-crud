using MediatR;
using Microsoft.Extensions.Logging;
using Users.Application.Contracts;

namespace Users.Application.Features.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UpdateUserCommandHandler> _logger;

        public UpdateUserCommandHandler(IUserRepository userRepository, ILogger<UpdateUserCommandHandler> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var dbUser = await _userRepository.GetByIdAsync(request.Id);

            if (dbUser == null)
            {
                throw new ArgumentException($"User with id {request.Id} could not be found!");
            }

            dbUser.FirstName = request.FirstName;
            dbUser.LastName = request.LastName;
            dbUser.Email = request.Email;
            dbUser.StatusId = request.Status;

            await _userRepository.UpdateAsync(dbUser);

            return dbUser.Id;
        }
    }
}
