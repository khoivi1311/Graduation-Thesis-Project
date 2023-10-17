using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface IDiscussionReplyCommentActionsRepository
    {
        Task<DiscussionReplyCommentActions> findDiscussionReplyCommentActionsByUserIdAndReplyCommentId(int userId, int replyCommentId);

        Task createNewDiscussionReplyCommentAction(DiscussionReplyCommentActions discussionReplyCommentAction);

        Task updateDiscussionReplyCommentAction(DiscussionReplyCommentActions discussionReplyCommentAction);

        Task<IEnumerable<DiscussionReplyCommentActions>> getAllDiscussionReplyCommentActions();
    }
}
