using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IGetCoursesManagementFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class GetCoursesManagementFunction : IGetCoursesManagementFunction
    {
        private readonly ICoursesServices _coursesServices;

        public GetCoursesManagementFunction(ICoursesServices coursesServices)
        {
            _coursesServices = coursesServices;
        }

        public async Task<Response> GetCoursesManagement(Request request)
        {
            var response = await _coursesServices.GetCoursesManagement(request);
            return new Response(response.ToList());
        }
    }
}
