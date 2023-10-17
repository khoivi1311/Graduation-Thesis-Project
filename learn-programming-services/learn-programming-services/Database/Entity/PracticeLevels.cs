using System.ComponentModel.DataAnnotations;

namespace learn_programming_services.Database.Entity
{
    public class PracticeLevels
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }


        public ICollection<Practices> Practices { get; set; }
    }
}
