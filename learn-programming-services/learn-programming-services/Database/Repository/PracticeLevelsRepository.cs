using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class PracticeLevelsRepository : IPracticeLevelsRepository
    {
        private readonly LearnProgrammingContext _context;

        public PracticeLevelsRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PracticeLevels>> getAllPracticeLevels()
        {
            return await _context.PracticeLevels.AsNoTracking().ToListAsync();
        }
    }
}
