using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace learn_programming_services.Database.Entity
{
    [Index(nameof(UserName), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class Users
    {
        [Key]
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? PhoneNumber { get; set; }

        public string UserName { get; set; }
        
        public string Email { get; set; }

        public string Password { get; set; }

        public string? Avatar { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(Roles))]
        public int RoleId { get; set; }
        public Roles Role { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
        

        public ICollection<Courses> Courses { get; set; }
        public ICollection<UserPermissions> UserPermissions { get; set; }
        public ICollection<Lessons> Lessons { get; set; }
        public ICollection<LessonComments> LessonComments { get; set; }
        public ICollection<LessonReplyComments> LessonReplyComments { get; set; }
        public ICollection<LessonHistories> LessonHistories { get; set; }
        public ICollection<UserTokens> UserTokens { get; set; }
        public ICollection<UserStudyCourses> UserStudyCourses { get; set; }
        public ICollection<UserLearnedLessons> UserLearnedLessons { get; set; }
        public ICollection<CourseComments> CourseComments { get; set; }
        public ICollection<CourseReplyComments> CourseReplyComments { get; set; }
        public ICollection<CourseCommentActions> CourseCommentActions { get; set; }
        public ICollection<CourseReplyCommentActions> CourseReplyCommentActions { get; set; }
        public ICollection<LessonCommentActions> LessonCommentActions { get; set; }
        public ICollection<LessonReplyCommentActions> LessonReplyCommentActions { get; set; }
        public ICollection<CourseVotes> CourseVotes { get; set; }
        public ICollection<UserRegisterContests> UserRegisterContests { get; set; }
        public ICollection<ContestTasks> ContestTasks { get; set; }
        public ICollection<Contests> Contests { get; set; }
        public ICollection<ContestTaskHistories> ContestTaskHistories { get; set; }
        public ICollection<Practices> Practices { get; set; }
        public ICollection<PracticeHistories> PracticeHistories { get; set; }
        public ICollection<Discussions> Discussions { get; set; }
        public ICollection<DiscussionComments> DiscussionComments { get; set; }
        public ICollection<DiscussionReplyComments> DiscussionReplyComments { get; set; }
        public ICollection<DiscussionCommentActions> DiscussionCommentActions { get; set; }
        public ICollection<DiscussionReplyCommentActions> DiscussionReplyCommentActions { get; set; }
    }
}
