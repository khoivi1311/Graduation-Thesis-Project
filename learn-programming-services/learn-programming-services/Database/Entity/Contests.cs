using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace learn_programming_services.Database.Entity
{
    public class Contests
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Information { get; set; }

        public string Location { get; set; }

        public string VerificationCode { get; set; }

        [ForeignKey(nameof(ContestStatuses))]
        public int ContestStatusId { get; set; }
        public ContestStatuses ContestStatus { get; set; }

        [ForeignKey(nameof(Users))]
        public int AuthorId { get; set; }
        public Users Author { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsHidden { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }


        public ICollection<UserRegisterContests> UserRegisterContests { get; set; }
        public ICollection<ContestTasks> ContestTasks { get; set; }
    }
}
