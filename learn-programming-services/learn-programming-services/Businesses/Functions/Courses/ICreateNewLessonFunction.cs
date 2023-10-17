using learn_programming_services.Apis.Courses.Dtos;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface ICreateNewLessonFunction
    {
        public class Request
        {
            public CreateNewLessonDto newLesson { get; set; }

            public Request(CreateNewLessonDto newLesson)
            {
                this.newLesson = newLesson;
            }
        }

        public class Response
        {
            public bool isSuccessful { get; set; }

            public List<string> errorMessages { get; set; }

            public Response(bool isSuccessful, List<string> errorMessages)
            {
                this.isSuccessful = isSuccessful;
                this.errorMessages = errorMessages;
            }
        }

        Task<Response> CreateNewLesson(Request request);
    }
}
