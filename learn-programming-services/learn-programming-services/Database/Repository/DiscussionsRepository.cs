using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class DiscussionsRepository : IDiscussionsRepository
    {
        private readonly LearnProgrammingContext _context;

        public DiscussionsRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task createNewDiscussion(Discussions discussions)
        {
            _context.Discussions.Add(discussions);
            await _context.SaveChangesAsync();
        }

        public async Task<Discussions> findDiscussionById(int id)
        {
            return await _context.Discussions.FindAsync(id);
        }

        public async Task updateDiscussion(Discussions discussions)
        {
            _context.Discussions.Update(discussions);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Discussions>> getAllDiscussions()
        {
            return await _context.Discussions.AsNoTracking().ToListAsync();
        }
    }
}
