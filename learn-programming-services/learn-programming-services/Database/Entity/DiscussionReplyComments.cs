using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace learn_programming_services.Database.Entity
{
    public class DiscussionReplyComments
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(DiscussionComments))]
        public int DiscussionCommentId { get; set; }
        public DiscussionComments DiscussionComment { get; set; }

        [ForeignKey(nameof(Users))]
        public int AuthorId { get; set; }
        public Users Author { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }


        public ICollection<DiscussionReplyCommentActions> DiscussionReplyCommentActions { get; set; }
    }
}
