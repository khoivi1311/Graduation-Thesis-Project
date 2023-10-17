using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.ICourseCommentActionFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class CourseCommentActionFunction : ICourseCommentActionFunction
    {
        private readonly ICoursesServices _coursesServices;

        public CourseCommentActionFunction(ICoursesServices coursesServices)
        {
            _coursesServices = coursesServices;
        }

        public async Task<Response> CourseCommentAction(Request request)
        {
            if (request.courseCommentAction.commentId > 0 && request.courseCommentAction.userId > 0)
            {
                if (request.courseCommentAction.actionId >= 0 && request.courseCommentAction.actionId <= 1)
                {
                    var response = await _coursesServices.CourseCommentAction(request);
                    return response;
                }
                else
                {
                    return new Response(false, "The action invalid");
                }
            }

            return new Response(false, "The fields are not allowed to be null");
        }
    }
}
