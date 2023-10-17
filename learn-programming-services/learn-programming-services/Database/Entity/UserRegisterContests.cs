using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace learn_programming_services.Database.Entity
{
    public class UserRegisterContests
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Contests))]
        public int ContestId { get; set; }
        public Contests Contest { get; set; }

        [ForeignKey(nameof(Users))]
        public int UserId { get; set; }
        public Users User { get; set; }

        public DateTime? EnrolledDate { get; set; }

        public DateTime? FinishedDate { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
