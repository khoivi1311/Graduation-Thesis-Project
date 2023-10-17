using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace learn_programming_services.Database.Entity
{
    public class DiscussionComments
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(Discussions))]
        public int DiscussionId { get; set; }
        public Discussions Discussion { get; set; }

        [ForeignKey(nameof(Users))]
        public int AuthorId { get; set; }
        public Users Author { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }


        public ICollection<DiscussionReplyComments> DiscussionReplyComments { get; set; }
        public ICollection<DiscussionCommentActions> DiscussionCommentActions { get; set; }
    }
}
