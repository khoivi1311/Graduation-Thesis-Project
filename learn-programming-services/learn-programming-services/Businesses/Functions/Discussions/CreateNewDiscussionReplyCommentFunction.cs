using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Discussions.ICreateNewDiscussionReplyCommentFunction;

namespace learn_programming_services.Businesses.Functions.Discussions
{
    public class CreateNewDiscussionReplyCommentFunction : ICreateNewDiscussionReplyCommentFunction
    {
        private readonly IDiscussionsServices _discussionsServices;

        public CreateNewDiscussionReplyCommentFunction(IDiscussionsServices discussionsServices)
        {
            _discussionsServices = discussionsServices;
        }

        public async Task<Response> CreateNewDiscussionReplyComment(Request request)
        {
            if (request.discussionReplyComment.userId > 0 &&
                request.discussionReplyComment.discussionCommentId > 0 &&
               (request.discussionReplyComment.content != null && request.discussionReplyComment.content.Trim() != ""))
            {
                var response = await _discussionsServices.CreateNewDiscussionReplyComment(request);
                return response;
            }

            return new Response(false, "The fields are not allowed to be null");
        }
    }
}
