using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class UserStudyCoursesRepository : IUserStudyCoursesRepository
    {
        private readonly LearnProgrammingContext _context;

        public UserStudyCoursesRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserStudyCourses>> getAllUserStudyCourses()
        {
            return await _context.UserStudyCourses.AsNoTracking().ToListAsync();
        }

        public async Task createNewUserStudyCourse(UserStudyCourses userStudyCourse)
        {
            _context.UserStudyCourses.Add(userStudyCourse);
            await _context.SaveChangesAsync();
        }

        public async Task<UserStudyCourses> findUserStudyCourseByCourseIdAndUserId(int courseId, int userId)
        {
            return await _context.UserStudyCourses
                .Where(u => u.CourseId.Equals(courseId))
                .Where(u => u.UserId.Equals(userId)).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task updateUserStudyCourse(UserStudyCourses userStudyCourse)
        {
            _context.UserStudyCourses.Update(userStudyCourse);
            await _context.SaveChangesAsync();
        }
    }
}
