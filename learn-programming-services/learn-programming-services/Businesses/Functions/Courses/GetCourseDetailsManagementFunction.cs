using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IGetCourseDetailsManagementFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class GetCourseDetailsManagementFunction : IGetCourseDetailsManagementFunction
    {
        private readonly ICoursesServices _coursesServices;

        public GetCourseDetailsManagementFunction(ICoursesServices coursesServices)
        {
            _coursesServices = coursesServices;
        }

        public async Task<Response> GetCourseDetailsManagement(Request request)
        {
            var response = await _coursesServices.GetCourseDetailsManagement(request);
            return response;
        }
    }
}
