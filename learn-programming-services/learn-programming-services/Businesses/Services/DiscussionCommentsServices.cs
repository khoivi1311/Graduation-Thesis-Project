using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class DiscussionCommentsServices : IDiscussionCommentsServices
    {
        private readonly IDiscussionCommentsRepository _discussionCommentsRepository;

        public DiscussionCommentsServices(IDiscussionCommentsRepository discussionCommentsRepository)
        {
            _discussionCommentsRepository = discussionCommentsRepository;
        }

        public async Task CreateNewDiscussionComment(DiscussionComments discussionComment)
        {
            await _discussionCommentsRepository.createNewDiscussionComment(discussionComment);
        }

        public async Task<DiscussionComments> FindDiscussionCommentById(int id)
        {
            return await _discussionCommentsRepository.findDiscussionCommentById(id);
        }

        public async Task UpdateDiscussionComment(DiscussionComments discussionComment)
        {
            await _discussionCommentsRepository.updateDiscussionComment(discussionComment);
        }

        public async Task<IEnumerable<DiscussionComments>> GetAllDiscussionComments()
        {
            return await _discussionCommentsRepository.getAllDiscussionComments();
        }

        public async Task<IEnumerable<DiscussionComments>> FindDiscussionCommentByDiscussionId(int discussionId)
        {
            return await _discussionCommentsRepository.findDiscussionCommentByDiscussionId(discussionId);
        }
    }
}
