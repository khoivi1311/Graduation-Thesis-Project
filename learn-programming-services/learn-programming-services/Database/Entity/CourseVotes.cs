using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace learn_programming_services.Database.Entity
{
    public class CourseVotes
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Courses))]
        public int CourseId { get; set; }
        public Courses Course { get; set; }

        [ForeignKey(nameof(Users))]
        public int UserId { get; set; }
        public Users User { get; set; }

        public int Score { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
