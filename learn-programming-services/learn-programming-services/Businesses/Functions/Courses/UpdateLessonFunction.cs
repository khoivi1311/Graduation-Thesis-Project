using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IUpdateLessonFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class UpdateLessonFunction : IUpdateLessonFunction
    {
        private readonly ILessonsServices _lessonsServices;

        public UpdateLessonFunction(ILessonsServices lessonsServices)
        {
            _lessonsServices = lessonsServices;
        }

        public async Task<Response> UpdateLesson(Request request)
        {
            if(request.lesson.lessonId > 0 &&
              (request.lesson.lessonName != null && request.lesson.lessonName.Trim() != "") &&
              (request.lesson.content != null && request.lesson.content.Trim() != "") &&
               request.lesson.score > 0 &&
              (request.lesson.testCases != null && request.lesson.testCases.Count() > 0) &&
              (request.lesson.codeSamples != null && request.lesson.codeSamples.Count() > 0))
            {
                var response = await _lessonsServices.UpdateLesson(request);
                return response;
            }

            return new Response(false, "The fields are not allowed to be null");
        }
    }
}
