using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class ContestStatusesRepository : IContestStatusesRepository
    {
        private readonly LearnProgrammingContext _context;

        public ContestStatusesRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContestStatuses>> getAllContestStatuses()
        {
            return await _context.ContestStatuses.AsNoTracking().ToListAsync();
        }
    }
}
