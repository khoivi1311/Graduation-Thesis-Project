using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class UserLearnedLessonsRepository : IUserLearnedLessonsRepository
    {
        private readonly LearnProgrammingContext _context;

        public UserLearnedLessonsRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserLearnedLessons>> getAllUserLearnedLessons()
        {
            return await _context.UserLearnedLessons.AsNoTracking().ToListAsync();
        }

        public async Task createNewUserLearnedLesson(UserLearnedLessons userLearnedLesson)
        {
            _context.UserLearnedLessons.Add(userLearnedLesson);
            await _context.SaveChangesAsync();
        }

        public async Task<UserLearnedLessons> findUserLearnedLessonByUserIdLessonId(int userId, int lessonId)
        {
            return await _context.UserLearnedLessons
                .Where(u => u.UserId.Equals(userId))
                .Where(u => u.LessonId.Equals(lessonId))
                .AsNoTracking().SingleOrDefaultAsync();
        }
    }
}
