using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.ILessonCommentFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class LessonCommentFunction : ILessonCommentFunction
    {
        private readonly ILessonsServices _lessonsServices;

        public LessonCommentFunction(ILessonsServices lessonsServices)
        {
            _lessonsServices = lessonsServices;
        }

        public async Task<Response> LessonComment(Request request)
        {
            if (request.lessonComment.lessonId > 0 && request.lessonComment.userId > 0 && request.lessonComment.content != null && request.lessonComment.content.Trim() != "")
            {
                var response = await _lessonsServices.LessonComment(request);
                return response;
            }

            return new Response(false, "The fields are not allowed to be null");
        }
    }
}
