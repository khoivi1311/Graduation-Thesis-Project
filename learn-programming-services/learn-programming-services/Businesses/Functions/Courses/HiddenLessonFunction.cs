using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IHiddenLessonFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class HiddenLessonFunction : IHiddenLessonFunction
    {
        private readonly ILessonsServices _lessonsServices;

        public HiddenLessonFunction(ILessonsServices lessonsServices)
        {
            _lessonsServices = lessonsServices;
        }

        public async Task<Response> HiddenLesson(Request request)
        {
            var response = await _lessonsServices.HiddenLesson(request);
            return response;
        }
    }
}
