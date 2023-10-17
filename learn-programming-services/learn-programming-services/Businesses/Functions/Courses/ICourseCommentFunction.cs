using learn_programming_services.Apis.Courses.Dtos;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface ICourseCommentFunction
    {
        public class Request
        {
            public CourseCommentDto courseComment { get; set; }

            public Request(CourseCommentDto courseComment) 
            {
                this.courseComment = courseComment;
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

        Task<Response> CourseComment(Request request);
    }
}
