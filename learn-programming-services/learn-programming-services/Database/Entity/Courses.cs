using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace learn_programming_services.Database.Entity
{
    public class Courses
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Objective { get; set; }

        public string Reward { get; set; }

        public int Time { get; set; }

        public string Image { get; set; }

        public string Theme { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsHidden { get; set; }

        [ForeignKey(nameof(CourseLevels))]
        public int CourseLevelId { get; set; }
        public CourseLevels CourseLevel { get; set; }

        [ForeignKey(nameof(Users))]
        public int AuthorId { get; set; }
        public Users Author { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }


        public ICollection<Chapters> Chapters { get; set; }
        public ICollection<UserStudyCourses> UserStudyCourses { get; set; }
        public ICollection<UserLearnedLessons> UserLearnedLessons { get; set; }
        public ICollection<CourseComments> CourseComments { get; set; }
        public ICollection<CourseVotes> CourseVotes { get; set; }
    }
}
