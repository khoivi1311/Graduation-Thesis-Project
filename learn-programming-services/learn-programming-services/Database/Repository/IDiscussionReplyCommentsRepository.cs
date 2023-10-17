using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface IDiscussionReplyCommentsRepository
    {
        Task createNewDiscussionReplyComment(DiscussionReplyComments discussionReplyComment);

        Task<DiscussionReplyComments> findDiscussionReplyCommentById(int id);

        Task updateDiscussionReplyComment(DiscussionReplyComments discussionReplyComment);

        Task<IEnumerable<DiscussionReplyComments>> getAllDiscussionReplyComments();

        Task<IEnumerable<DiscussionReplyComments>> findDiscussionReplyCommentByCommentId(int commentId);
    }
}
