namespace Users.Application.Features.Queries
{
    public class PermissionDto
    {
        public int UserId { get; set; }

        public IEnumerable<int> PermissionIds { get; set; }
    }
}
