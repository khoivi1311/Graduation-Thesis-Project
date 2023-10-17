using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Contests.IGetContestsManagementFunction;

namespace learn_programming_services.Businesses.Functions.Contests
{
    public class GetContestsManagementFunction : IGetContestsManagementFunction
    {
        private readonly IContestsServices _contestsServices;

        public GetContestsManagementFunction(IContestsServices contestsServices)
        {
            _contestsServices = contestsServices;
        }

        public async Task<Response> GetContestsManagement(Request request)
        {
            if(request.userId > 0)
            {
                var response = await _contestsServices.GetContestsManagement(request);
                return response;
            }
            return new Response(null);
        }
    }
}
