using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class PracticeTestCasesRepository : IPracticeTestCasesRepository
    {
        private readonly LearnProgrammingContext _context;

        public PracticeTestCasesRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task createNewPracticeTestCase(PracticeTestCases practiceTestCase)
        {
            _context.PracticeTestCases.Add(practiceTestCase);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PracticeTestCases>> findPracticeTestCasesByPracticeId(int practiceId)
        {
            return await _context.PracticeTestCases.Where(p => p.PracticeId.Equals(practiceId)).AsNoTracking().ToListAsync();
        }

        public async Task<PracticeTestCases> findPracticeTestCaseById(int id)
        {
            return await _context.PracticeTestCases.FindAsync(id);
        }

        public async Task updatePracticeTestCase(PracticeTestCases practiceTestCase)
        {
            _context.PracticeTestCases.Update(practiceTestCase);
            await _context.SaveChangesAsync();
        }
    }
}
