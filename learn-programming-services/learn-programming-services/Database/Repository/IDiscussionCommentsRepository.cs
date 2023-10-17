using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface IDiscussionCommentsRepository
    {
        Task createNewDiscussionComment(DiscussionComments discussionComment);

        Task<DiscussionComments> findDiscussionCommentById(int id);

        Task updateDiscussionComment(DiscussionComments discussionComment);

        Task<IEnumerable<DiscussionComments>> getAllDiscussionComments();

        Task<IEnumerable<DiscussionComments>> findDiscussionCommentByDiscussionId(int discussionId);
    }
}
