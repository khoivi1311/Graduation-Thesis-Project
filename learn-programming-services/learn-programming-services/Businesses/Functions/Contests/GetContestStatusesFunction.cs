using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Contests.IGetContestStatusesFunction;

namespace learn_programming_services.Businesses.Functions.Contests
{
    public class GetContestStatusesFunction : IGetContestStatusesFunction
    {
        private readonly IContestStatusesServices _contestStatusesServices;

        public GetContestStatusesFunction(IContestStatusesServices contestStatusesServices)
        {
            _contestStatusesServices = contestStatusesServices;
        }

        public async Task<Response> GetContestStatuses()
        {
            var response = await _contestStatusesServices.GetContestStatuses();
            return response;
        }
    }
}
