using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class DiscussionReplyCommentsRepository : IDiscussionReplyCommentsRepository
    {
        private readonly LearnProgrammingContext _context;

        public DiscussionReplyCommentsRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task createNewDiscussionReplyComment(DiscussionReplyComments discussionReplyComment)
        {
            _context.DiscussionReplyComments.Add(discussionReplyComment);
            await _context.SaveChangesAsync();
        }

        public async Task<DiscussionReplyComments> findDiscussionReplyCommentById(int id)
        {
            return await _context.DiscussionReplyComments.FindAsync(id);
        }

        public async Task updateDiscussionReplyComment(DiscussionReplyComments discussionReplyComment)
        {
            _context.DiscussionReplyComments.Update(discussionReplyComment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DiscussionReplyComments>> getAllDiscussionReplyComments()
        {
            return await _context.DiscussionReplyComments.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<DiscussionReplyComments>> findDiscussionReplyCommentByCommentId(int commentId)
        {
            return await _context.DiscussionReplyComments
                .Where(d => d.DiscussionCommentId.Equals(commentId))
                .AsNoTracking().ToListAsync();
        }
    }
}
