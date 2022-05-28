using System.ComponentModel.DataAnnotations;

namespace Users.Domain.Entities
{
    public  class Status
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
