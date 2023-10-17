using learn_programming_services.Apis.Courses.Dtos;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface ICourseReplyCommentFunction
    {
        public class Request
        {
            public CourseReplyCommentDto courseReplyComment { get; set; }

            public Request(CourseReplyCommentDto courseReplyComment)
            {
                this.courseReplyComment = courseReplyComment;
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

        Task<Response> CourseReplyComment(Request request);
    }
}
