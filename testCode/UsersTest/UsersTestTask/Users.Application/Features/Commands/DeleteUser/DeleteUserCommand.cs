using MediatR;

namespace Users.Application.Features.Commands
{
    public record DeleteUserCommand(int Id) : IRequest;
}
