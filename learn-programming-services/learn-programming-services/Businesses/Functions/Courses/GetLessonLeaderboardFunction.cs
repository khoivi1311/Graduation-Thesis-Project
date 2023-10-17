using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IGetLessonLeaderboardFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class GetLessonLeaderboardFunction : IGetLessonLeaderboardFunction
    {
        private readonly ILessonHistoriesServices _lessonHistoriesServices;

        public GetLessonLeaderboardFunction(ILessonHistoriesServices lessonHistoriesServices)
        {
            _lessonHistoriesServices = lessonHistoriesServices;
        }

        public async Task<Response> GetLessonLeaderboard(Request request)
        {
            if(request.lessonId > 0 && request.pageSize > 0 && request.pageNumber > 0) 
            {
                var response = await _lessonHistoriesServices.GetLessonLeaderboard(request);
                return response;
            }

            return new Response(0, null);
        }
    }
}
