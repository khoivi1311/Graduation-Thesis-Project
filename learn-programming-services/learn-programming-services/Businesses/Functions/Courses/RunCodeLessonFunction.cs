using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IRunCodeLessonFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class RunCodeLessonFunction : IRunCodeLessonFunction
    {
        private readonly ILessonsServices _lessonsServices;

        public RunCodeLessonFunction(ILessonsServices lessonsServices)
        {
            _lessonsServices = lessonsServices;
        }

        public async Task<Response> RunCodeLesson(Request request)
        {
            if(request.runCodeLesson.lessonId > 0 &&
              (request.runCodeLesson.lessonCode != null && request.runCodeLesson.lessonCode.Trim() != "") &&
              request.runCodeLesson.codeLanguageId > 0)
            {
                var response = await _lessonsServices.RunCodeLesson(request);
                return response;
            }

            return new Response(null, "Request error", "The fields are not allowed to be null", null);
        }
    }
}
