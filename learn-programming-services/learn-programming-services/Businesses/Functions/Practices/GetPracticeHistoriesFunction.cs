using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Practices.IGetPracticeHistoriesFunction;

namespace learn_programming_services.Businesses.Functions.Practices
{
    public class GetPracticeHistoriesFunction : IGetPracticeHistoriesFunction
    {
        private readonly IPracticeHistoriesServices _practiceHistoriesServices;

        public GetPracticeHistoriesFunction(IPracticeHistoriesServices practiceHistoriesServices)
        {
            _practiceHistoriesServices = practiceHistoriesServices;
        }

        public async Task<Response> GetPracticeHistories(Request request)
        {
            if(request.practiceId > 0 && request.userId > 0)
            {
                var response = await _practiceHistoriesServices.GetPracticeHistories(request);
                return response;
            }

            return new Response(null);
        }
    }
}
