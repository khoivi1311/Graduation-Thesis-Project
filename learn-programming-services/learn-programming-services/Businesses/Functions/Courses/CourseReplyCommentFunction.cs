using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.ICourseReplyCommentFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class CourseReplyCommentFunction : ICourseReplyCommentFunction
    {
        private readonly ICoursesServices _coursesServices;

        public CourseReplyCommentFunction(ICoursesServices coursesServices)
        {
            _coursesServices = coursesServices;
        }

        public async Task<Response> CourseReplyComment(Request request)
        {
            if (request.courseReplyComment.courseCommentId > 0 && request.courseReplyComment.userId > 0 && request.courseReplyComment.content != null && request.courseReplyComment.content.Trim() != "")
            {
                var response = await _coursesServices.CourseReplyComment(request);
                return response;
            }

            return new Response(false, "The fields are not allowed to be null");
        }
    }
}
