using System.ComponentModel.DataAnnotations;
using Users.Domain.Common;

namespace Users.Domain.Entities
{
    public class User : EntityBase
    {
        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }

        [StringLength(20)]
        public string Username { get; set; }

        public string Password { get; set; }

        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        // Foreign key for Status
        public int StatusId { get; set; }

        public Status Status { get; set; }

        public ICollection<UserPermission> UserPermissions{ get; set; }
    }
}
