using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IGetLessonCommentsFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class GetLessonCommentsFunction : IGetLessonCommentsFunction
    {
        private readonly ILessonsServices _lessonsServices;

        public GetLessonCommentsFunction(ILessonsServices lessonsServices)
        {
            _lessonsServices = lessonsServices;
        }

        public async Task<Response> GetLessonComments(Request request)
        {
            if(request.lessonId > 0 && request.userId > 0)
            {
                var response = await _lessonsServices.GetLessonComments(request);
                return response;
            }
            return new Response();
        }
    }
}
