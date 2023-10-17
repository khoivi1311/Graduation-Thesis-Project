using learn_programming_services.Apis.Courses.Dtos;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface ICourseRegisterFunction
    {
        public class Request
        {
            public CourseRegisterDto courseRegister { get; set; }

            public Request(CourseRegisterDto courseRegister)
            {
                this.courseRegister = courseRegister;
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

        Task<Response> CourseRegister(Request request);
    }
}
