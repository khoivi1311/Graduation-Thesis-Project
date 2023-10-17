using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface IDiscussionCommentsServices
    {
        Task CreateNewDiscussionComment(DiscussionComments discussionComment);

        Task<DiscussionComments> FindDiscussionCommentById(int id);

        Task UpdateDiscussionComment(DiscussionComments discussionComment);

        Task<IEnumerable<DiscussionComments>> GetAllDiscussionComments();

        Task<IEnumerable<DiscussionComments>> FindDiscussionCommentByDiscussionId(int discussionId);
    }
}
