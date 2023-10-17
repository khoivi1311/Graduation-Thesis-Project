using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.ICourseRegisterFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class CourseRegisterFunction : ICourseRegisterFunction
    {
        private readonly ICoursesServices _coursesServices;

        public CourseRegisterFunction(ICoursesServices coursesServices)
        {
            _coursesServices = coursesServices;
        }

        public async Task<Response> CourseRegister(Request request)
        {
            if (request.courseRegister.courseId > 0 && request.courseRegister.userId > 0)
            {
                var response = await _coursesServices.CourseRegister(request);
                return response;
            }

            return new Response(false, "The fields are not allowed to be null");
        }
    }
}
