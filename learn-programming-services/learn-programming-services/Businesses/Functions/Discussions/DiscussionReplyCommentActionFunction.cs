using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Discussions.IDiscussionReplyCommentActionFunction;

namespace learn_programming_services.Businesses.Functions.Discussions
{
    public class DiscussionReplyCommentActionFunction : IDiscussionReplyCommentActionFunction
    {
        private readonly IDiscussionsServices _discussionsServices;

        public DiscussionReplyCommentActionFunction(IDiscussionsServices discussionsServices)
        {
            _discussionsServices = discussionsServices;
        }

        public async Task<Response> DiscussionReplyCommentAction(Request request)
        {
            if (request.discussionReplyCommentAction.commentId > 0 && request.discussionReplyCommentAction.userId > 0)
            {
                if (request.discussionReplyCommentAction.actionId >= 0 && request.discussionReplyCommentAction.actionId <= 1)
                {
                    var response = await _discussionsServices.DiscussionReplyCommentAction(request);
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
