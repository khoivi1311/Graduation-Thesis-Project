using learn_programming_services.Apis.Courses.Dtos;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface IUpdateCourseFunction
    {
        public class Request
        {
            public UpdateCourseDto course { get; set; }

            public Request(UpdateCourseDto course) 
            {
                this.course = course;
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

        Task<Response> UpdateCourse(Request request);
    }
}
