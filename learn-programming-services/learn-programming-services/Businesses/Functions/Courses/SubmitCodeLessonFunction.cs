using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.ISubmitCodeLessonFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class SubmitCodeLessonFunction : ISubmitCodeLessonFunction
    {
        private readonly ILessonsServices _lessonsServices;

        public SubmitCodeLessonFunction(ILessonsServices lessonsServices)
        {
            _lessonsServices = lessonsServices;
        }

        public async Task<Response> SubmitCodeLesson(Request request)
        {
            if (request.submitCodeLesson.lessonId > 0 &&
              (request.submitCodeLesson.lessonCode != null && request.submitCodeLesson.lessonCode.Trim() != "") &&
              request.submitCodeLesson.codeLanguageId > 0 && request.submitCodeLesson.userId > 0)
            {
                var response = await _lessonsServices.SubmitCodeLesson(request);
                return response;
            }

            return new Response(null, null, null, 0);
        }
    }
}
