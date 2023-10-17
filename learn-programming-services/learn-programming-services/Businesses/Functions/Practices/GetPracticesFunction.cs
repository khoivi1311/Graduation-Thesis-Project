using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Practices.IGetPracticesFunction;

namespace learn_programming_services.Businesses.Functions.Practices
{
    public class GetPracticesFunction : IGetPracticesFunction
    {
        private readonly IPracticesServices _practicesServices;

        public GetPracticesFunction(IPracticesServices practicesServices)
        {
            _practicesServices = practicesServices;
        }

        public async Task<Response> GetPractices(Request request)
        {
            if(request.pageSize > 0 && request.pageNumber > 0)
            {
                var response = await _practicesServices.GetPractices(request);
                return response;
            }
            return new Response(0, null);
        }
    }
}
