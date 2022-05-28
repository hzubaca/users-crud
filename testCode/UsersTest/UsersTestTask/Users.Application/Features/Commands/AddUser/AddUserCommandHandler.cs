using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Users.Application.Contracts;
using Users.Domain.Entities;

namespace Users.Application.Features.Commands
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AddUserCommandHandler> _logger;

        public AddUserCommandHandler(IUserRepository userRepository, IMapper mapper, ILogger<AddUserCommandHandler> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = _mapper.Map<User>(request);
            var newUser = await _userRepository.AddAsync(userEntity);

            return newUser.Id;
        }
    }
}
