using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class DiscussionReplyCommentsServices : IDiscussionReplyCommentsServices
    {
        private readonly IDiscussionReplyCommentsRepository _discussionReplyCommentsRepository;

        public DiscussionReplyCommentsServices(IDiscussionReplyCommentsRepository discussionReplyCommentsRepository)
        {
            _discussionReplyCommentsRepository = discussionReplyCommentsRepository;
        }

        public async Task CreateNewDiscussionReplyComment(DiscussionReplyComments discussionReplyComment)
        {
            await _discussionReplyCommentsRepository.createNewDiscussionReplyComment(discussionReplyComment);
        }

        public async Task<DiscussionReplyComments> FindDiscussionReplyCommentById(int id)
        {
            return await _discussionReplyCommentsRepository.findDiscussionReplyCommentById(id);
        }

        public async Task UpdateDiscussionReplyComment(DiscussionReplyComments discussionReplyComment)
        {
            await _discussionReplyCommentsRepository.updateDiscussionReplyComment(discussionReplyComment);
        }

        public async Task<IEnumerable<DiscussionReplyComments>> GetAllDiscussionReplyComments()
        {
            return await _discussionReplyCommentsRepository.getAllDiscussionReplyComments();
        }

        public async Task<IEnumerable<DiscussionReplyComments>> FindDiscussionReplyCommentByCommentId(int commentId)
        {
            return await _discussionReplyCommentsRepository.findDiscussionReplyCommentByCommentId(commentId);
        }
    }
}
