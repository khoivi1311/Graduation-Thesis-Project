using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace learn_programming_services.Database.Entity
{
    public class Chapters
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsHidden { get; set; }

        [ForeignKey(nameof(Courses))]
        public int CourseId { get; set; }
        public Courses Course { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }


        public ICollection<Lessons> Lessons { get; set; }
        public ICollection<UserLearnedLessons> UserLearnedLessons { get; set; }
    }
}
