using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface IDiscussionCommentActionsRepository
    {
        Task<DiscussionCommentActions> findDiscussionCommentActionByUserIdAndCommentId(int userId, int commentId);

        Task createNewDiscussionCommentAction(DiscussionCommentActions discussionCommentAction);

        Task updateDiscussionCommentAction(DiscussionCommentActions discussionCommentAction);

        Task<IEnumerable<DiscussionCommentActions>> getAllDiscussionCommentActions();
    }
}
