using learn_programming_services.Apis.Discussions.Dtos;

namespace learn_programming_services.Businesses.Functions.Discussions
{
    public interface ICreateNewDiscussionCommentFunction
    {
        public class Request
        {
            public CreateNewDiscussionCommentDto discussionComment { get; set; }

            public Request(CreateNewDiscussionCommentDto discussionComment)
            {
                this.discussionComment = discussionComment;
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

        Task<Response> CreateNewDiscussionComment(Request request);
    }
}
