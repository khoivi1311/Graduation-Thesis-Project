namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface IDeleteCourseReplyCommentFunction
    {
        public class Request
        {
            public int replyCommentId { get; set; }

            public int userId { get; set; }

            public Request(int replyCommentId, int userId)
            {
                this.replyCommentId = replyCommentId;
                this.userId = userId;
            }
        }

        public class Response
        {
            public bool isSuccessful { get; set; }

            public string errorMessage { get; set; }

            public Response(bool isSuccessful, string errorMessage)
            {
                this.isSuccessful = isSuccessful;
                this.errorMessage = errorMessage;
            }
        }

        Task<Response> DeleteCourseReplyComment(Request request);
    }
}
