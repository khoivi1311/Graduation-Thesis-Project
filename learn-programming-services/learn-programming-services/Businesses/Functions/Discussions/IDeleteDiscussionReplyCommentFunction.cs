namespace learn_programming_services.Businesses.Functions.Discussions
{
    public interface IDeleteDiscussionReplyCommentFunction
    {
        public class Request
        {
            public int userId { get; set; }

            public int replyCommentId { get; set; }

            public Request(int userId, int replyCommentId)
            {
                this.userId = userId;
                this.replyCommentId = replyCommentId;
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

        Task<Response> DeleteDiscussionReplyComment(Request request);
    }
}
