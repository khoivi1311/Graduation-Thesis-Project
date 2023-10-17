using learn_programming_services.Apis.Courses.Dtos;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface ILessonCommentFunction
    {
        public class Request
        {
            public LessonCommentDto lessonComment { get; set; }

            public Request(LessonCommentDto lessonComment) 
            {
                this.lessonComment = lessonComment;
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

        Task<Response> LessonComment(Request request);
    }
}
