using learn_programming_services.Apis.Courses.Dtos;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface IUpdateLessonFunction
    {
        public class Request
        {
            public UpdateLessonDto lesson { get; set; }

            public Request(UpdateLessonDto lesson)
            {
                this.lesson = lesson;
            }
        }

        public class Response
        {
            public bool isSuccessful { get; set; }

            public string errorMessages { get; set; }

            public Response(bool isSuccessful, string errorMessages)
            {
                this.isSuccessful = isSuccessful;
                this.errorMessages = errorMessages;
            }
        }

        Task<Response> UpdateLesson(Request request);
    }
}
