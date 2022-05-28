using System.ComponentModel.DataAnnotations;

namespace Users.Domain.Entities
{
    public class Permission
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public ICollection<UserPermission> UserPermissions { get; set; }
    }
}
