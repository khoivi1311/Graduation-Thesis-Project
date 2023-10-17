using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class DiscussionCommentActionsServices : IDiscussionCommentActionsServices
    {
        private readonly IDiscussionCommentActionsRepository _discussionCommentActionsRepository;

        public DiscussionCommentActionsServices(IDiscussionCommentActionsRepository discussionCommentActionsRepository)
        {
            _discussionCommentActionsRepository = discussionCommentActionsRepository;
        }

        public async Task<DiscussionCommentActions> FindDiscussionCommentActionByUserIdAndCommentId(int userId, int commentId)
        {
            return await _discussionCommentActionsRepository.findDiscussionCommentActionByUserIdAndCommentId(userId, commentId);
        }

        public async Task CreateNewDiscussionCommentAction(DiscussionCommentActions discussionCommentAction)
        {
            await _discussionCommentActionsRepository.createNewDiscussionCommentAction(discussionCommentAction);
        }

        public async Task UpdateDiscussionCommentAction(DiscussionCommentActions discussionCommentAction)
        {
            await _discussionCommentActionsRepository.updateDiscussionCommentAction(discussionCommentAction);
        }

        public async Task<IEnumerable<DiscussionCommentActions>> GetAllDiscussionCommentActions()
        {
            return await _discussionCommentActionsRepository.getAllDiscussionCommentActions();
        }
    }
}
