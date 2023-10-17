using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface IDiscussionReplyCommentsServices
    {
        Task CreateNewDiscussionReplyComment(DiscussionReplyComments discussionReplyComment);

        Task<DiscussionReplyComments> FindDiscussionReplyCommentById(int id);

        Task UpdateDiscussionReplyComment(DiscussionReplyComments discussionReplyComment);

        Task<IEnumerable<DiscussionReplyComments>> GetAllDiscussionReplyComments();

        Task<IEnumerable<DiscussionReplyComments>> FindDiscussionReplyCommentByCommentId(int commentId);
    }
}
