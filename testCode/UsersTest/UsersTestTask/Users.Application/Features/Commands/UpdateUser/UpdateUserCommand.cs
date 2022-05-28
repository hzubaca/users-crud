using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Users.Application.Features.Commands
{
    public class UpdateUserCommand : IRequest<int>
    {
        [Required(ErrorMessage = "Id is required field.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required field.")]
        [MinLength(1)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required field.")]
        [MinLength(1)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required field.")]
        [EmailAddress(ErrorMessage = "Email address must be in the correct format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Status must be set for the user.")]
        [Range(1, 2)]
        public int Status { get; set; }
    }
}
