using learn_programming_services.Apis.Courses.Dtos;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface ICourseReplyCommentActionFunction
    {
        public class Request
        {
            public CourseCommentActionDto courseReplyCommentAction { get; set; }

            public Request(CourseCommentActionDto courseReplyCommentAction)
            {
                this.courseReplyCommentAction = courseReplyCommentAction;
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

        Task<Response> CourseReplyCommentAction(Request request);
    }
}
