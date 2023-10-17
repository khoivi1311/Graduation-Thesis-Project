using System.ComponentModel.DataAnnotations;

namespace learn_programming_services.Database.Entity
{
    public class Permissions
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }


        public ICollection<UserPermissions> UserPermissions { get; set; }
    }
}
