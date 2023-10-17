using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class ContestsRepository : IContestsRepository
    {
        private readonly LearnProgrammingContext _context;

        public ContestsRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contests>> getAllContests()
        {
            return await _context.Contests.AsNoTracking().ToListAsync();
        }
    }
}
