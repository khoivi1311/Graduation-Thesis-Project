using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace learn_programming_services.Database.Entity
{
    public class Lessons
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public int Score { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsHidden { get; set; }

        [ForeignKey(nameof(Chapters))]
        public int ChapterId { get; set; }
        public Chapters Chapter { get; set; }

        [ForeignKey(nameof(Users))]
        public int AuthorId { get; set; }
        public Users Author { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public ICollection<LessonTestCases> LessonsTestCases { get; set; }
        public ICollection<LessonComments> LessonComments { get; set; }
        public ICollection<LessonHistories> LessonHistories { get; set; }
        public ICollection<UserLearnedLessons> UserLearnedLessons { get; set; }
        public ICollection<LessonCodeSamples> LessonCodeSamples { get; set; }
    }
}
