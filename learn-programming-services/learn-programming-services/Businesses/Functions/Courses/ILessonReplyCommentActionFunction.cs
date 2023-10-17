using learn_programming_services.Apis.Courses.Dtos;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface ILessonReplyCommentActionFunction
    {
        public class Request
        {
            public LessonCommentActionDto lessonReplyCommentAction { get; set; }

            public Request(LessonCommentActionDto lessonReplyCommentAction)
            {
                this.lessonReplyCommentAction = lessonReplyCommentAction;
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

        Task<Response> LessonReplyCommentAction(Request request);
    }
}
