using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class DiscussionCommentActionsRepository : IDiscussionCommentActionsRepository
    {
        private readonly LearnProgrammingContext _context;

        public DiscussionCommentActionsRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task<DiscussionCommentActions> findDiscussionCommentActionByUserIdAndCommentId(int userId, int commentId)
        {
            return await _context.DiscussionCommentActions
                .Where(d => d.UserId.Equals(userId))
                .Where(d => d.DiscussionCommentId.Equals(commentId))
                .AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task createNewDiscussionCommentAction(DiscussionCommentActions discussionCommentAction)
        {
            _context.DiscussionCommentActions.Add(discussionCommentAction);
            await _context.SaveChangesAsync();
        }

        public async Task updateDiscussionCommentAction(DiscussionCommentActions discussionCommentAction)
        {
            _context.DiscussionCommentActions.Update(discussionCommentAction);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DiscussionCommentActions>> getAllDiscussionCommentActions()
        {
            return await _context.DiscussionCommentActions.AsNoTracking().ToListAsync();
        }
    }
}
