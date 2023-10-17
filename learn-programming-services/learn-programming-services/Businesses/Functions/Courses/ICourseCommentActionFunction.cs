using learn_programming_services.Apis.Courses.Dtos;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface ICourseCommentActionFunction
    {
        public class Request
        {
            public CourseCommentActionDto courseCommentAction { get; set; }

            public Request(CourseCommentActionDto courseCommentAction) 
            {
                this.courseCommentAction = courseCommentAction;
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

        Task<Response> CourseCommentAction(Request request);
    }
}
