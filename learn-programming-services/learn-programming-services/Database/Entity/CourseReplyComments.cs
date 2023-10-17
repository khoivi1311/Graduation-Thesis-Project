using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace learn_programming_services.Database.Entity
{
    public class CourseReplyComments
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(CourseComments))]
        public int CourseCommentId { get; set; }
        public CourseComments CourseComment { get; set; }

        [ForeignKey(nameof(Users))]
        public int AuthorId { get; set; }
        public Users Author { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }


        public ICollection<CourseReplyCommentActions> CourseReplyCommentActions { get; set; }
    }
}
