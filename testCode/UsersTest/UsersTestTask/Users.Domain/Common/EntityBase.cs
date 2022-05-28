namespace Users.Domain.Common
{
    public class EntityBase
    {
        public int Id { get; set; }

        public DateTime? DateCreated { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? DateModified { get; set; }

        public int? ModifiedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}
