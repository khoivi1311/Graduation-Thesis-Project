using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface IDiscussionCommentActionsServices
    {
        Task<DiscussionCommentActions> FindDiscussionCommentActionByUserIdAndCommentId(int userId, int commentId);

        Task CreateNewDiscussionCommentAction(DiscussionCommentActions discussionCommentAction);

        Task UpdateDiscussionCommentAction(DiscussionCommentActions discussionCommentAction);

        Task<IEnumerable<DiscussionCommentActions>> GetAllDiscussionCommentActions();
    }
}
