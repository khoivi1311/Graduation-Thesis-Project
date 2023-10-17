using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IDeleteCourseFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class DeleteCourseFunction : IDeleteCourseFunction
    {
        private readonly ICoursesServices _coursesServices;

        public DeleteCourseFunction(ICoursesServices coursesServices)
        {
            _coursesServices = coursesServices;
        }

        public async Task<Response> DeleteCourse(Request request)
        {
            var response = await _coursesServices.DeleteCourse(request);
            return response;
        }
    }
}
