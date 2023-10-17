using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class LessonsRepository : ILessonsRepository
    {
        private readonly LearnProgrammingContext _context;

        public LessonsRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lessons>> getAllLessons()
        {
            return await _context.Lessons.AsNoTracking().ToListAsync();
        }

        public async Task createNewLesson(Lessons lesson)
        {
            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();
        }

        public async Task<Lessons> findLatestLesson()
        {
            return await _context.Lessons.OrderByDescending(u => u.Id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Lessons> findLessonById(int id)
        {
            return await _context.Lessons.FindAsync(id);
        }

        public async Task updateLesson(Lessons lesson)
        {
            _context.Lessons.Update(lesson);
            await _context.SaveChangesAsync();
        }
    }
}
