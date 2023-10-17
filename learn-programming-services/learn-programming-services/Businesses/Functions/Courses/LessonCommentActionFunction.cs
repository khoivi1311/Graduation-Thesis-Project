using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.ILessonCommentActionFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class LessonCommentActionFunction : ILessonCommentActionFunction
    {
        private readonly ILessonsServices _lessonsServices;

        public LessonCommentActionFunction(ILessonsServices lessonsServices)
        {
            _lessonsServices = lessonsServices;
        }

        public async Task<Response> LessonCommentAction(Request request)
        {
            if (request.lessonCommentAction.commentId > 0 && request.lessonCommentAction.userId > 0)
            {
                if (request.lessonCommentAction.actionId >= 0 && request.lessonCommentAction.actionId <= 1)
                {
                    var response = await _lessonsServices.LessonCommentAction(request);
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
