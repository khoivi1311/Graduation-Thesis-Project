namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface IDeleteCourseCommentFunction
    {
        public class Request
        {
            public int commentId { get; set; }

            public int userId { get; set; }

            public Request(int commentId, int userId)
            {
                this.commentId = commentId;
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

        Task<Response> DeleteCourseComment(Request request);
    }
}
