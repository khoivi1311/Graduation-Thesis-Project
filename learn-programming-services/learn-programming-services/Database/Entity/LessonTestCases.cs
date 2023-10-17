using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace learn_programming_services.Database.Entity
{
    public class LessonTestCases
    {
        [Key]
        public int Id { get; set; }

        public string Input { get; set; }

        public string ExpectedOutput { get; set; }

        public bool IsHidden { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(Lessons))]
        public int LessonId { get; set; }
        public Lessons Lesson { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
