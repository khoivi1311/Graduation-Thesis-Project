using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Practices.IGetPracticeLeaderboardFunction;

namespace learn_programming_services.Businesses.Functions.Practices
{
    public class GetPracticeLeaderboardFunction : IGetPracticeLeaderboardFunction
    {
        private readonly IPracticeHistoriesServices _practiceHistoriesServices;

        public GetPracticeLeaderboardFunction(IPracticeHistoriesServices practiceHistoriesServices)
        {
            _practiceHistoriesServices = practiceHistoriesServices;
        }

        public async Task<Response> GetPracticeLeaderboard(Request request)
        {
            if (request.practiceId > 0 && request.pageSize > 0 && request.pageNumber > 0)
            {
                var response = await _practiceHistoriesServices.GetPracticeLeaderboard(request);
                return response;
            }

            return new Response(0, null);
        }
    }
}
