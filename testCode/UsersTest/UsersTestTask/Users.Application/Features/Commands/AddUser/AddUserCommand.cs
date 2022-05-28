using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Users.Application.Features.Commands
{
    public class AddUserCommand : IRequest<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int Status { get; set; }
    }
}
