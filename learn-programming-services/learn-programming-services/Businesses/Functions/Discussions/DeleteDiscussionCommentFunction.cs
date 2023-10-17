using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Discussions.IDeleteDiscussionCommentFunction;

namespace learn_programming_services.Businesses.Functions.Discussions
{
    public class DeleteDiscussionCommentFunction : IDeleteDiscussionCommentFunction
    {
        private readonly IDiscussionsServices _discussionsServices;

        public DeleteDiscussionCommentFunction(IDiscussionsServices discussionsServices)
        {
            _discussionsServices = discussionsServices;
        }

        public async Task<Response> DeleteDiscussionComment(Request request)
        {
            var response = await _discussionsServices.DeleteDiscussionComment(request);
            return response;
        }
    }
}
