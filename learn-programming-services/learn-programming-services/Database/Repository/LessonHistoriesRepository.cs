using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class LessonHistoriesRepository : ILessonHistoriesRepository
    {
        private readonly LearnProgrammingContext _context;

        public LessonHistoriesRepository( LearnProgrammingContext context )
        {
            _context = context;
        }

        public async Task<IEnumerable<LessonHistories>> findLessonHistoryByUserIdAndLessonId(int userId, int lessonId)
        {
            return await _context.LessonHistories
                .Where(l => l.LessonId.Equals(lessonId))
                .Where(l => l.AuthorId.Equals(userId))
                .AsNoTracking().ToListAsync();
        }

        public async Task createNewLessonHistory(LessonHistories lessonHistory)
        {
            _context.LessonHistories.Add(lessonHistory);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LessonHistories>> findLessonHistoryByLessonId(int lessonId)
        {
            return await _context.LessonHistories
                .Where(l => l.LessonId.Equals(lessonId))
                .AsNoTracking().ToListAsync();
        }
    }
}
