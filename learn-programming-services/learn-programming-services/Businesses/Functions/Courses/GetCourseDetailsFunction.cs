using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IGetCourseDetailsFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class GetCourseDetailsFunction : IGetCourseDetailsFunction
    {
        private readonly ICoursesServices _coursesServices;

        public GetCourseDetailsFunction(ICoursesServices coursesServices)
        {
            _coursesServices = coursesServices;
        }

        public async Task<Response> GetCourseDetails(Request request)
        {
            var response = await _coursesServices.GetCourseDetails(request);
            return response;
        }
    }
}
