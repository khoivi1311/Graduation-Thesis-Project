using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class DiscussionCommentsRepository : IDiscussionCommentsRepository
    {
        private readonly LearnProgrammingContext _context;

        public DiscussionCommentsRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task createNewDiscussionComment(DiscussionComments discussionComment)
        {
            _context.DiscussionComments.Add(discussionComment);
            await _context.SaveChangesAsync();
        }

        public async Task<DiscussionComments> findDiscussionCommentById(int id)
        {
            return await _context.DiscussionComments.FindAsync(id);
        }

        public async Task updateDiscussionComment(DiscussionComments discussionComment)
        {
            _context.DiscussionComments.Update(discussionComment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DiscussionComments>> getAllDiscussionComments()
        {
            return await _context.DiscussionComments.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<DiscussionComments>> findDiscussionCommentByDiscussionId(int discussionId)
        {
            return await _context.DiscussionComments
                .Where(d => d.DiscussionId.Equals(discussionId))
                .AsNoTracking().ToListAsync();
        }
    }
}
