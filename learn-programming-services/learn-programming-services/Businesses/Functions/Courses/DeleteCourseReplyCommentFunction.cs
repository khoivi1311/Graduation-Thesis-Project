using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IDeleteCourseReplyCommentFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class DeleteCourseReplyCommentFunction : IDeleteCourseReplyCommentFunction
    {
        private readonly ICoursesServices _coursesServices;

        public DeleteCourseReplyCommentFunction(ICoursesServices coursesServices)
        {
            _coursesServices = coursesServices;
        }

        public async Task<Response> DeleteCourseReplyComment(Request request)
        {
            if (request.replyCommentId > 0 && request.userId > 0)
            {
                var response = await _coursesServices.DeleteCourseReplyComment(request);
                return response;
            }

            return new Response(false, "The fields are not allowed to be null");
        }
    }
}
