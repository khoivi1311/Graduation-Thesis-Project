using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Practices.IGetPracticeDetailsFunction;

namespace learn_programming_services.Businesses.Functions.Practices
{
    public class GetPracticeDetailsFunction : IGetPracticeDetailsFunction
    {
        private readonly IPracticesServices _practicesServices;

        public GetPracticeDetailsFunction(IPracticesServices practicesServices)
        {
            _practicesServices = practicesServices;
        }

        public async Task<Response> GetPracticeDetails(Request request)
        {
            if (request.practiceId > 0)
            {
                var response = await _practicesServices.GetPracticeDetails(request);
                return response;
            }

            return new Response();
        }
    }
}
