using learn_programming_services.Apis.Courses.Dtos;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface ILessonReplyCommentFunction
    {
        public class Request 
        {
            public LessonReplyCommentDto lessonReplyComment { get; set; }

            public Request(LessonReplyCommentDto lessonReplyComment) 
            {
                this.lessonReplyComment = lessonReplyComment;
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

        Task<Response> LessonReplyComment(Request request);
    }
}
