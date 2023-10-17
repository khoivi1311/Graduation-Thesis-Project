using learn_programming_services.Apis.Courses.Dtos;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface ICreateNewCourseFunction
    {
        public class Request 
        {
            public CreateNewCourseDto newCourse { get; set; }

            public Request(CreateNewCourseDto newCourse)
            {
                this.newCourse = newCourse;
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

        Task<Response> CreateNewCourse(Request request);
    }
}
