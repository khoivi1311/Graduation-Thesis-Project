using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace learn_programming_services.Database.Entity
{
    public class LessonComments
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(Lessons))]
        public int LessonId { get; set; }
        public Lessons Lesson { get; set; }

        [ForeignKey(nameof(Users))]
        public int AuthorId { get; set; }
        public Users Author { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        
        public ICollection<LessonReplyComments> LessonReplyComments { get; set; }
        public ICollection<LessonCommentActions> LessonCommentActions { get; set; }

    }
}
