using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace learn_programming_services.Database.Entity
{
    public class PracticeHistories
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(CodeLanguages))]
        public int CodeLanguageId { get; set; }
        public CodeLanguages CodeLanguage { get; set; }

        public string TestCase { get; set; }

        public int Score { get; set; }

        public string CodeSubmitted { get; set; }

        public DateTime SubmittedDate { get; set; }

        [ForeignKey(nameof(Practices))]
        public int PracticeId { get; set; }
        public Practices Practice { get; set; }

        [ForeignKey(nameof(Users))]
        public int AuthorId { get; set; }
        public Users Author { get; set; }
    }
}
