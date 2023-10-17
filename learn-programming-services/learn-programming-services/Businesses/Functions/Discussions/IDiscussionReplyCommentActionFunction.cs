using learn_programming_services.Apis.Discussions.Dtos;

namespace learn_programming_services.Businesses.Functions.Discussions
{
    public interface IDiscussionReplyCommentActionFunction
    {
        public class Request
        {
            public DiscussionCommentActionDto discussionReplyCommentAction { get; set; }

            public Request(DiscussionCommentActionDto discussionReplyCommentAction)
            {
                this.discussionReplyCommentAction = discussionReplyCommentAction;
            }
        }

        public class Response
        {
            public bool isSuccessful { get; set; }

            public string errorMessages { get; set; }

            public Response(bool isSuccessful, string errorMessages)
            {
                this.isSuccessful = isSuccessful;
                this.errorMessages = errorMessages;
            }
        }

        Task<Response> DiscussionReplyCommentAction(Request request);
    }
}
