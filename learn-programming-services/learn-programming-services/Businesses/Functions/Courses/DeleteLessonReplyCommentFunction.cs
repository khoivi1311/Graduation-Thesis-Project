using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IDeleteLessonReplyCommentFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class DeleteLessonReplyCommentFunction : IDeleteLessonReplyCommentFunction
    {
        private readonly ILessonsServices _lessonsServices;

        public DeleteLessonReplyCommentFunction(ILessonsServices lessonsServices)
        {
            _lessonsServices = lessonsServices;
        }

        public async Task<Response> DeleteLessonReplyComment(Request request)
        {
            if (request.replyCommentId > 0 && request.userId > 0)
            {
                var response = await _lessonsServices.DeleteLessonReplyComment(request);
                return response;
            }

            return new Response(false, "The fields are not allowed to be null");
        }
    }
}
