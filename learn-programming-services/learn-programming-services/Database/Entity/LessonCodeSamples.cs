using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace learn_programming_services.Database.Entity
{
    public class LessonCodeSamples
    {
        [Key]
        public int Id { get; set; }

        public string CodeSample { get; set; }

        [ForeignKey(nameof(CodeLanguages))]
        public int CodeLanguageId { get; set; }
        public CodeLanguages CodeLanguage { get; set; }

        [ForeignKey(nameof(Lessons))]
        public int LessonId { get; set; }
        public Lessons Lesson { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
