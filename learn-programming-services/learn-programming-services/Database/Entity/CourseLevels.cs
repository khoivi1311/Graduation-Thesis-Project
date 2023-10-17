using System.ComponentModel.DataAnnotations;

namespace learn_programming_services.Database.Entity
{
    public class CourseLevels
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }


        public ICollection<Courses> Courses { get; set; }
    }
}
