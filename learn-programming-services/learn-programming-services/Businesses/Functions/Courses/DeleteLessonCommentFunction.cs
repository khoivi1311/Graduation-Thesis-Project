using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IDeleteLessonCommentFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class DeleteLessonCommentFunction : IDeleteLessonCommentFunction
    {
        private readonly ILessonsServices _lessonsServices;

        public DeleteLessonCommentFunction(ILessonsServices lessonsServices)
        {
            _lessonsServices = lessonsServices;
        }

        public async Task<Response> DeleteLessonComment(Request request)
        {
            if (request.commentId > 0 && request.userId > 0)
            {
                var response = await _lessonsServices.DeleteLessonComment(request);
                return response;
            }

            return new Response(false, "The fields are not allowed to be null");
        }
    }
}
