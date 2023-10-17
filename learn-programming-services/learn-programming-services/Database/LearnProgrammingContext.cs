using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Seeds;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database
{
    public class LearnProgrammingContext : DbContext
    {
        public LearnProgrammingContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<CourseLevels> CourseLevels { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<LessonComments> LessonComments { get; set; }
        public DbSet<LessonHistories> LessonHistories { get; set; }
        public DbSet<LessonReplyComments> LessonReplyComments { get; set; }
        public DbSet<Lessons> Lessons { get; set; }
        public DbSet<LessonTestCases> LessonTestCases { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Chapters> Chapters { get; set; }
        public DbSet<UserPermissions> UserPermissions { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserTokens> UserTokens { get; set; }
        public DbSet<UserStudyCourses> UserStudyCourses { get; set; }
        public DbSet<UserLearnedLessons> UserLearnedLessons { get; set; }
        public DbSet<CourseComments> CourseComments { get; set; }
        public DbSet<CourseReplyComments> CourseReplyComments { get; set; }
        public DbSet<CourseCommentActions> CourseCommentActions { get; set; }
        public DbSet<CourseReplyCommentActions> CourseReplyCommentActions { get; set; }
        public DbSet<LessonCommentActions> LessonCommentActions { get; set; }
        public DbSet<LessonReplyCommentActions> LessonReplyCommentActions { get; set; }
        public DbSet<CourseVotes> CourseVotes { get; set; }
        public DbSet<CodeLanguages> CodeLanguages { get; set; }
        public DbSet<LessonCodeSamples> LessonCodeSamples { get; set; }
        public DbSet<Themes> Themes { get; set; }
        public DbSet<ContestStatuses> ContestStatuses { get; set; }
        public DbSet<Contests> Contests { get; set; }
        public DbSet<UserRegisterContests> UserRegisterContests { get; set; }
        public DbSet<ContestTasks> ContestTasks { get; set; }
        public DbSet<ContestTaskTestCases> ContestTaskTestCases { get; set; }
        public DbSet<ContestTaskCodeLanguages> ContestTaskCodeLanguages { get; set; }
        public DbSet<ContestTaskHistories> ContestTaskHistories { get; set; }
        public DbSet<Practices> Practices { get; set; }
        public DbSet<PracticeLevels> PracticeLevels { get; set; }
        public DbSet<PracticeTestCases> PracticeTestCases { get; set; }
        public DbSet<PracticeHistories> PracticeHistories { get; set; }
        public DbSet<Discussions> Discussions { get; set; }
        public DbSet<DiscussionComments> DiscussionComments { get; set; }
        public DbSet<DiscussionReplyComments> DiscussionReplyComments { get; set; }
        public DbSet<DiscussionCommentActions> DiscussionCommentActions { get; set; }
        public DbSet<DiscussionReplyCommentActions> DiscussionReplyCommentActions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            //Add Seeding Data
            ConfigurationSeedingData(modelBuilder);
        }

        private static void ConfigurationSeedingData(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseLevelsSeedingData());
            modelBuilder.ApplyConfiguration(new RolesSeedingData());
            modelBuilder.ApplyConfiguration(new PermissionsSeedingData());
            modelBuilder.ApplyConfiguration(new CodeLanguagesSeedingData());
            modelBuilder.ApplyConfiguration(new ThemesSeedingData());
            modelBuilder.ApplyConfiguration(new ContestStatusesSeedingData());
            modelBuilder.ApplyConfiguration(new PracticeLevelsSeedingData()); 
        }
    }
}
