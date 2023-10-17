using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IDeleteLessonFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class DeleteLessonFunction : IDeleteLessonFunction
    {
        private readonly ILessonsServices _lessonsServices;

        public DeleteLessonFunction(ILessonsServices lessonsServices)
        {
            _lessonsServices = lessonsServices;
        }

        public async Task<Response> DeleteLesson(Request request)
        {
            var response = await _lessonsServices.DeleteLesson(request);
            return response;
        }
    }
}
