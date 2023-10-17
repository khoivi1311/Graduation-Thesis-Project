using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Practices.IGetPracticesManagementFunction;

namespace learn_programming_services.Businesses.Functions.Practices
{
    public class GetPracticesManagementFunction : IGetPracticesManagementFunction
    {
        private readonly IPracticesServices _practicesServices;

        public GetPracticesManagementFunction(IPracticesServices practicesServices)
        {
            _practicesServices = practicesServices;
        }

        public async Task<Response> GetPracticesManagement(Request request)
        {
            if (request.userId > 0 && request.pageSize > 0 && request.pageNumber > 0)
            {
                var response = await _practicesServices.GetPracticesManagement(request);
                return response;
            }

            return new Response(0, null);
        }
    }
}
