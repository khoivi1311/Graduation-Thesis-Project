using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace learn_programming_services.Database.Entity
{
    public class ContestTaskCodeLanguages
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(CodeLanguages))]
        public int CodeLanguageId { get; set; }
        public CodeLanguages CodeLanguage { get; set; }

        [ForeignKey(nameof(ContestTasks))]
        public int ContestTaskId { get; set; }
        public ContestTasks ContestTask { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
