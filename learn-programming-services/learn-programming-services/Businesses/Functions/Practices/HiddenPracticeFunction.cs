using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Practices.IHiddenPracticeFunction;

namespace learn_programming_services.Businesses.Functions.Practices
{
    public class HiddenPracticeFunction : IHiddenPracticeFunction
    {
        private readonly IPracticesServices _practicesServices;

        public HiddenPracticeFunction(IPracticesServices practicesServices)
        {
            _practicesServices = practicesServices;
        }

        public async Task<Response> HiddenPractice(Request request)
        {
            var response = await _practicesServices.HiddenPractice(request);
            return response;
        }
    }
}
