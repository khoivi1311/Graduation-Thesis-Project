using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IDeleteCourseCommentFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class DeleteCourseCommentFunction : IDeleteCourseCommentFunction
    {
        private readonly ICoursesServices _coursesServices;

        public DeleteCourseCommentFunction(ICoursesServices coursesServices)
        {
            _coursesServices = coursesServices;
        }

        public async Task<Response> DeleteCourseComment(Request request)
        {
            if (request.commentId > 0 && request.userId > 0)
            {
                var response = await _coursesServices.DeleteCourseComment(request);
                return response;
            }

            return new Response(false, "The fields are not allowed to be null");
        }
    }
}
