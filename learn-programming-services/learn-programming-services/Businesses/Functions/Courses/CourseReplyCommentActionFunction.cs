using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.ICourseReplyCommentActionFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class CourseReplyCommentActionFunction : ICourseReplyCommentActionFunction
    {
        private readonly ICoursesServices _coursesServices;

        public CourseReplyCommentActionFunction(ICoursesServices coursesServices)
        {
            _coursesServices = coursesServices;
        }

        public async Task<Response> CourseReplyCommentAction(Request request)
        {
            if (request.courseReplyCommentAction.commentId > 0 && request.courseReplyCommentAction.userId > 0)
            {
                if (request.courseReplyCommentAction.actionId >= 0 && request.courseReplyCommentAction.actionId <= 1)
                {
                    var response = await _coursesServices.CourseReplyCommentAction(request);
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
