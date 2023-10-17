using learn_programming_services.Apis.Discussions.Dtos;

namespace learn_programming_services.Businesses.Functions.Discussions
{
    public interface ICreateNewDiscussionReplyCommentFunction
    {
        public class Request
        {
            public CreateNewDiscussionReplyCommentDto discussionReplyComment { get; set; }

            public Request(CreateNewDiscussionReplyCommentDto discussionReplyComment)
            {
                this.discussionReplyComment = discussionReplyComment;
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

        Task<Response> CreateNewDiscussionReplyComment(Request request);
    }
}
