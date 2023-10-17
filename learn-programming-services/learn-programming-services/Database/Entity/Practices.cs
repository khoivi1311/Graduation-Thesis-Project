using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace learn_programming_services.Database.Entity
{
    public class Practices
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public int Score { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsHidden { get; set; }

        [ForeignKey(nameof(PracticeLevels))]
        public int PracticeLevelId { get; set; }
        public PracticeLevels PracticeLevel { get; set; }

        [ForeignKey(nameof(Users))]
        public int AuthorId { get; set; }
        public Users Author { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }


        public ICollection<PracticeTestCases> PracticeTestCases { get; set; }
        public ICollection<PracticeHistories> PracticeHistories { get; set; }
    }
}
