using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace learn_programming_services.Database.Entity
{
    public class PracticeTestCases
    {
        [Key]
        public int Id { get; set; }

        public string Input { get; set; }

        public string ExpectedOutput { get; set; }

        public bool IsHidden { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(Practices))]
        public int PracticeId { get; set; }
        public Practices Practice { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
