using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.ICourseCommentFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class CourseCommentFunction : ICourseCommentFunction
    {
        private readonly ICoursesServices _coursesServices;

        public CourseCommentFunction(ICoursesServices coursesServices)
        {
            _coursesServices = coursesServices;
        }

        public async Task<Response> CourseComment(Request request)
        {
            if (request.courseComment.courseId > 0 && request.courseComment.userId > 0 && request.courseComment.content != null && request.courseComment.content.Trim() != "")
            {
                var response = await _coursesServices.CourseComment(request);
                return response;
            }

            return new Response(false, "The fields are not allowed to be null");
        }
    }
}
