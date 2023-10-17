using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace learn_programming_services.Database.Entity
{
    public class UserPermissions
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Users))]
        public int UserId { get; set; }
        public Users User { get; set; }

        [ForeignKey(nameof(Permissions))]
        public int PermissionId { get; set; }
        public Permissions Permission { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
