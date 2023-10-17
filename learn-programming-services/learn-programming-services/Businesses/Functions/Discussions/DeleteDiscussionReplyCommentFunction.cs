using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Discussions.IDeleteDiscussionReplyCommentFunction;

namespace learn_programming_services.Businesses.Functions.Discussions
{
    public class DeleteDiscussionReplyCommentFunction : IDeleteDiscussionReplyCommentFunction
    {
        private readonly IDiscussionsServices _discussionsServices;

        public DeleteDiscussionReplyCommentFunction(IDiscussionsServices discussionsServices)
        {
            _discussionsServices = discussionsServices;
        }

        public async Task<Response> DeleteDiscussionReplyComment(Request request)
        {
            var response = await _discussionsServices.DeleteDiscussionReplyComment(request);
            return response;
        }
    }
}
