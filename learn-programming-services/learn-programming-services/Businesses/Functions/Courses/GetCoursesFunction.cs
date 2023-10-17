using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IGetCoursesFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class GetCoursesFunction : IGetCoursesFunction
    {
        private readonly ICoursesServices _coursesServices;

        public GetCoursesFunction(ICoursesServices coursesServices)
        {
            _coursesServices = coursesServices;
        }

        public async Task<Response> GetCourses(Request request)
        {
            var coursesList = await _coursesServices.GetCourses(request);
            return new Response(coursesList.ToList());
        }
    }
}
