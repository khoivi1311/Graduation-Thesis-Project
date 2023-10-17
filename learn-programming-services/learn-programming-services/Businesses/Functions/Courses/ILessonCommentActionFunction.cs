using learn_programming_services.Apis.Courses.Dtos;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface ILessonCommentActionFunction
    {
        public class Request
        {
            public LessonCommentActionDto lessonCommentAction { get; set; }

            public Request(LessonCommentActionDto lessonCommentAction)
            {
                this.lessonCommentAction = lessonCommentAction;
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

        Task<Response> LessonCommentAction(Request request);
    }
}
