using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Discussions.ICreateNewDiscussionCommentFunction;

namespace learn_programming_services.Businesses.Functions.Discussions
{
    public class CreateNewDiscussionCommentFunction : ICreateNewDiscussionCommentFunction
    {
        private readonly IDiscussionsServices _discussionsServices;

        public CreateNewDiscussionCommentFunction(IDiscussionsServices discussionsServices)
        {
            _discussionsServices = discussionsServices;
        }

        public async Task<Response> CreateNewDiscussionComment(Request request)
        {
            if (request.discussionComment.userId > 0 &&
                request.discussionComment.discussionId > 0 &&
               (request.discussionComment.content != null && request.discussionComment.content.Trim() != ""))
            {
                var response = await _discussionsServices.CreateNewDiscussionComment(request);
                return response;
            }

            return new Response(false, "The fields are not allowed to be null");
        }
    }
}
