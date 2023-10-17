using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class LessonTestCasesRepository : ILessonTestCasesRepository
    {
        private readonly LearnProgrammingContext _context;

        public LessonTestCasesRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task createNewLessonTestCase(LessonTestCases lessonTestCase)
        {
            _context.LessonTestCases.Add(lessonTestCase);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LessonTestCases>> findLessonTestCasesByLessonId(int lessonId)
        {
            return await _context.LessonTestCases.Where(l => l.LessonId.Equals(lessonId)).AsNoTracking().ToListAsync();
        }

        public async Task updateLessonTestCase(LessonTestCases lessonTestCase)
        {
            _context.LessonTestCases.Update(lessonTestCase);
            await _context.SaveChangesAsync();
        }

        public async Task<LessonTestCases> findLessonTestCaseById(int id)
        {
            return await _context.LessonTestCases.FindAsync(id);
        }
    }
}
