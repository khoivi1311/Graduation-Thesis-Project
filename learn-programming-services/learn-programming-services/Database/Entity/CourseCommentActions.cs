using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace learn_programming_services.Database.Entity
{
    public class CourseCommentActions
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(CourseComments))]
        public int CourseCommentId { get; set; }
        public CourseComments CourseComment { get; set; }

        [ForeignKey(nameof(Users))]
        public int UserId { get; set; }
        public Users User { get; set; }

        public bool IsLiked { get; set; }

        public bool IsDisliked { get; set; }
    }
}
