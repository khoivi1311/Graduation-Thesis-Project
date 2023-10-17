using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace learn_programming_services.Database.Entity
{
    public class Discussions
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public string Image { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(Users))]
        public int AuthorId { get; set; }
        public Users Author { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }


        public ICollection<DiscussionComments> DiscussionComments { get; set; }
    }
}
