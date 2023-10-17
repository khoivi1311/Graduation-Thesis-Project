using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace learn_programming_services.Database.Entity
{
    public class ContestTasks
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public int Score { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(Contests))]
        public int ContestId { get; set; }
        public Contests Contest { get; set; }

        [ForeignKey(nameof(Users))]
        public int AuthorId { get; set; }
        public Users Author { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }


        public ICollection<ContestTaskTestCases> ContestTaskTestCases { get; set; }
        public ICollection<ContestTaskCodeLanguages> ContestTaskCodeLanguages { get; set; }
        public ICollection<ContestTaskHistories> ContestTaskHistories { get; set; }
    }
}
