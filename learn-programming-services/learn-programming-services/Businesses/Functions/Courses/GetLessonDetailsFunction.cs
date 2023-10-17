using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IGetLessonDetailsFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class GetLessonDetailsFunction : IGetLessonDetailsFunction
    {
        private readonly ILessonsServices _lessonsServices;

        public GetLessonDetailsFunction(ILessonsServices lessonsServices)
        {
            _lessonsServices = lessonsServices;
        }

        public async Task<Response> GetLessonDetails(Request request)
        {
            if(request.lessonId > 0)
            {
                var response = await _lessonsServices.GetLessonDetails(request);
                return response;
            }
            return new Response();
        }
    }
}
