using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class DiscussionReplyCommentActionsRepository : IDiscussionReplyCommentActionsRepository
    {
        private readonly LearnProgrammingContext _context;

        public DiscussionReplyCommentActionsRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task<DiscussionReplyCommentActions> findDiscussionReplyCommentActionsByUserIdAndReplyCommentId(int userId, int replyCommentId)
        {
            return await _context.DiscussionReplyCommentActions
                .Where(d => d.UserId.Equals(userId))
                .Where(d => d.DiscussionReplyCommentId.Equals(replyCommentId))
                .AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task createNewDiscussionReplyCommentAction(DiscussionReplyCommentActions discussionReplyCommentAction)
        {
            _context.DiscussionReplyCommentActions.Add(discussionReplyCommentAction);
            await _context.SaveChangesAsync();
        }

        public async Task updateDiscussionReplyCommentAction(DiscussionReplyCommentActions discussionReplyCommentAction)
        {
            _context.DiscussionReplyCommentActions.Update(discussionReplyCommentAction);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DiscussionReplyCommentActions>> getAllDiscussionReplyCommentActions()
        {
            return await _context.DiscussionReplyCommentActions.AsNoTracking().ToListAsync();
        }
    }
}
