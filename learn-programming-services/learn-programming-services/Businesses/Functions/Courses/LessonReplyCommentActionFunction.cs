using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.ILessonReplyCommentActionFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class LessonReplyCommentActionFunction : ILessonReplyCommentActionFunction
    {
        private readonly ILessonsServices _lessonsServices;

        public LessonReplyCommentActionFunction(ILessonsServices lessonsServices)
        {
            _lessonsServices = lessonsServices;
        }

        public async Task<Response> LessonReplyCommentAction(Request request)
        {
            if (request.lessonReplyCommentAction.commentId > 0 && request.lessonReplyCommentAction.userId > 0)
            {
                if (request.lessonReplyCommentAction.actionId >= 0 && request.lessonReplyCommentAction.actionId <= 1)
                {
                    var response = await _lessonsServices.LessonReplyCommentAction(request);
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
