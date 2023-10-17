using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface IDiscussionReplyCommentActionsServices
    {
        Task<DiscussionReplyCommentActions> FindDiscussionReplyCommentActionsByUserIdAndReplyCommentId(int userId, int replyCommentId);

        Task CreateNewDiscussionReplyCommentAction(DiscussionReplyCommentActions discussionReplyCommentAction);

        Task UpdateDiscussionReplyCommentAction(DiscussionReplyCommentActions discussionReplyCommentAction);

        Task<IEnumerable<DiscussionReplyCommentActions>> GetAllDiscussionReplyCommentActions();
    }
}
