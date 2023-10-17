using System.ComponentModel.DataAnnotations;

namespace learn_programming_services.Database.Entity
{
    public class Themes
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public bool IsHidden { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
