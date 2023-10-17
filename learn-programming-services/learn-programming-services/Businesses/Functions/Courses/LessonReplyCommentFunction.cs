using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.ILessonReplyCommentFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class LessonReplyCommentFunction : ILessonReplyCommentFunction
    {
        private readonly ILessonsServices _lessonsServices;

        public LessonReplyCommentFunction(ILessonsServices lessonsServices)
        {
            _lessonsServices = lessonsServices;
        }

        public async Task<Response> LessonReplyComment(Request request)
        {
            if (request.lessonReplyComment.lessonCommentId > 0 && request.lessonReplyComment.userId > 0 && request.lessonReplyComment.content != null && request.lessonReplyComment.content.Trim() != "")
            {
                var response = await _lessonsServices.LessonReplyComment(request);
                return response;
            }

            return new Response(false, "The fields are not allowed to be null");
        }
    }
}
