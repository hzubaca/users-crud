namespace Users.Domain.Entities
{
    public class UserPermission
    {
        public int Id { get; set; }

        // Foreign key for User
        public int UserId { get; set; }

        // Foreign key for Permission
        public int PermissionId { get; set; }

        public User User { get; set; }

        public Permission Permission { get; set; }
    }
}
