using learn_programming_services.Apis.Discussions.Dtos;

namespace learn_programming_services.Businesses.Functions.Discussions
{
    public interface IDiscussionCommentActionFunction
    {
        public class Request
        {
            public DiscussionCommentActionDto discussionCommentAction { get; set; }

            public Request(DiscussionCommentActionDto discussionCommentAction) 
            {
                this.discussionCommentAction = discussionCommentAction;
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

        Task<Response> DiscussionCommentAction(Request request);
    }
}
