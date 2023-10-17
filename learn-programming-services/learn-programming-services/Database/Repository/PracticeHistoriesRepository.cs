using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class PracticeHistoriesRepository : IPracticeHistoriesRepository
    {
        private readonly LearnProgrammingContext _context;

        public PracticeHistoriesRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PracticeHistories>> getAllPracticeHistories()
        {
            return await _context.PracticeHistories.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<PracticeHistories>> findPracticeHistoriesByPracticeId(int practiceId)
        {
            return await _context.PracticeHistories.Where(p => p.PracticeId.Equals(practiceId)).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<PracticeHistories>> findPracticeHistoriesByUserIdAndPracticeId(int userId, int practiceId)
        {
            return await _context.PracticeHistories
                .Where(p => p.AuthorId.Equals(userId))
                .Where(p => p.PracticeId.Equals(practiceId))
                .AsNoTracking().ToListAsync();
        }

        public async Task createNewPracticeHistory(PracticeHistories practiceHistory)
        {
            _context.PracticeHistories.Add(practiceHistory);
            await _context.SaveChangesAsync();
        }
    }
}
