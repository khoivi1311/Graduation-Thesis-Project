using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Practices.IGetPracticeDetailsManagementFunction;

namespace learn_programming_services.Businesses.Functions.Practices
{
    public class GetPracticeDetailsManagementFunction : IGetPracticeDetailsManagementFunction
    {
        private readonly IPracticesServices _practicesServices;

        public GetPracticeDetailsManagementFunction(IPracticesServices practicesServices)
        {
            _practicesServices = practicesServices;
        }

        public async Task<Response> GetPracticeDetailsManagement(Request request)
        {
            if(request.id > 0)
            {
                var response = await _practicesServices.GetPracticeDetailsManagement(request);
                return response;
            }

            return new Response();
        }
    }
}
