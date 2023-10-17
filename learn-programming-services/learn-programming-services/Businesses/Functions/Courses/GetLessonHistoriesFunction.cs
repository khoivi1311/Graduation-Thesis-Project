using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IGetLessonHistoriesFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class GetLessonHistoriesFunction : IGetLessonHistoriesFunction
    {
        private readonly ILessonHistoriesServices _lessonHistoriesServices;

        public GetLessonHistoriesFunction(ILessonHistoriesServices lessonHistoriesServices)
        {
            _lessonHistoriesServices = lessonHistoriesServices;
        }

        public async Task<Response> GetLessonHistories(Request request)
        {
            if(request.lessonId > 0 && request.userId > 0)
            {
                var response = await _lessonHistoriesServices.GetLessonHistories(request);
                return response;
            }
            return new Response(null);
        }
    }
}
