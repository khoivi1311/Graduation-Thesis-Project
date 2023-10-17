namespace learn_programming_services.Businesses.Functions.Discussions
{
    public interface IDeleteDiscussionCommentFunction
    {
        public class Request
        {
            public int userId { get; set; }

            public int commentId { get; set; }

            public Request(int userId, int commentId)
            {
                this.userId = userId;
                this.commentId = commentId;
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

        Task<Response> DeleteDiscussionComment(Request request);
    }
}
