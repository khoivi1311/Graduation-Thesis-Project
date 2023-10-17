using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace learn_programming_services.Database.Entity
{
    public class CourseComments
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(Courses))]
        public int CourseId { get; set; }
        public Courses Course { get; set; }

        [ForeignKey(nameof(Users))]
        public int AuthorId { get; set; }
        public Users Author { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }


        public ICollection<CourseReplyComments> CourseReplyComments { get; set; }
        public ICollection<CourseCommentActions> CourseCommentActions { get; set; }
    }
}
