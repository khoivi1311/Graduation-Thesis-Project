using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IHiddenCourseFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class HiddenCourseFunction : IHiddenCourseFunction
    {
        private readonly ICoursesServices _coursesServices;

        public HiddenCourseFunction(ICoursesServices coursesServices)
        {
            _coursesServices = coursesServices;
        }

        public async Task<Response> HiddenCourse(Request request)
        {
            var response = await _coursesServices.HiddenCourse(request);
            return response;
        }
    }
}
