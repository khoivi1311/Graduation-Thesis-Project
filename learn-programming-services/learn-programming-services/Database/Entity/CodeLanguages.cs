using System.ComponentModel.DataAnnotations;

namespace learn_programming_services.Database.Entity
{
    public class CodeLanguages
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Version { get; set; }

        public string SubmitName { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }


        public ICollection<LessonCodeSamples> LessonCodeSamples { get; set; }
        public ICollection<LessonHistories> LessonHistories { get; set; }
        public ICollection<ContestTaskCodeLanguages> ContestTaskCodeLanguages { get; set; }
        public ICollection<ContestTaskHistories> ContestTaskHistories { get; set; }
        public ICollection<PracticeHistories> PracticeHistories { get; set; }
    }
}
