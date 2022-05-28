using MediatR;

namespace Users.Application.Features.Queries
{
    public record GetUserByIdQuery(int Id) : IRequest<UserDto>;
}
