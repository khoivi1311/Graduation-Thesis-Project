using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class DiscussionReplyCommentActionsServices : IDiscussionReplyCommentActionsServices
    {
        private readonly IDiscussionReplyCommentActionsRepository _discussionReplyCommentActionsRepository;

        public DiscussionReplyCommentActionsServices(IDiscussionReplyCommentActionsRepository discussionReplyCommentActionsRepository)
        {
            _discussionReplyCommentActionsRepository = discussionReplyCommentActionsRepository;
        }

        public async Task<DiscussionReplyCommentActions> FindDiscussionReplyCommentActionsByUserIdAndReplyCommentId(int userId, int replyCommentId)
        {
            return await _discussionReplyCommentActionsRepository.findDiscussionReplyCommentActionsByUserIdAndReplyCommentId(userId, replyCommentId);
        }

        public async Task CreateNewDiscussionReplyCommentAction(DiscussionReplyCommentActions discussionReplyCommentAction)
        {
            await _discussionReplyCommentActionsRepository.createNewDiscussionReplyCommentAction(discussionReplyCommentAction);
        }

        public async Task UpdateDiscussionReplyCommentAction(DiscussionReplyCommentActions discussionReplyCommentAction)
        {
            await _discussionReplyCommentActionsRepository.updateDiscussionReplyCommentAction(discussionReplyCommentAction);
        }

        public async Task<IEnumerable<DiscussionReplyCommentActions>> GetAllDiscussionReplyCommentActions()
        {
            return await _discussionReplyCommentActionsRepository.getAllDiscussionReplyCommentActions();
        }
    }
}
