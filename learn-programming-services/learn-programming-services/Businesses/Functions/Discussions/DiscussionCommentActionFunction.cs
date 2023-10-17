using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Discussions.IDiscussionCommentActionFunction;

namespace learn_programming_services.Businesses.Functions.Discussions
{
    public class DiscussionCommentActionFunction : IDiscussionCommentActionFunction
    {
        private readonly IDiscussionsServices _discussionsServices;

        public DiscussionCommentActionFunction(IDiscussionsServices discussionsServices)
        {
            _discussionsServices = discussionsServices;
        }

        public async Task<Response> DiscussionCommentAction(Request request)
        {
            if(request.discussionCommentAction.commentId > 0 && request.discussionCommentAction.userId > 0)
            {
                if (request.discussionCommentAction.actionId >= 0 && request.discussionCommentAction.actionId <= 1)
                {
                    var response = await _discussionsServices.DiscussionCommentAction(request);
                    return response;
                }
                else
                {
                    return new Response(false, "The action invalid");
                }
            }

            return new Response(false, "The fields are not allowed to be null");
        }
    }
}
