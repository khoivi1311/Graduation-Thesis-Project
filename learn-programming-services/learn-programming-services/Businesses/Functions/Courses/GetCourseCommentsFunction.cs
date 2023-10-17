using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IGetCourseCommentsFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class GetCourseCommentsFunction : IGetCourseCommentsFunction
    {
        private readonly ICoursesServices _coursesServices;

        public GetCourseCommentsFunction(ICoursesServices coursesServices)
        {
            _coursesServices = coursesServices;
        }

        public async Task<Response> GetCourseComments(Request request)
        {
            if (request.courseId > 0 && request.userId > 0)
            {
                var response = await _coursesServices.GetCourseComments(request);
                return response;
            }

            return new Response();
        }
    }
}
