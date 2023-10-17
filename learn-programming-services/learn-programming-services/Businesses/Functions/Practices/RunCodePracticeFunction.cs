using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Practices.IRunCodePracticeFunction;

namespace learn_programming_services.Businesses.Functions.Practices
{
    public class RunCodePracticeFunction : IRunCodePracticeFunction
    {
        private readonly IPracticesServices _practicesServices;

        public RunCodePracticeFunction(IPracticesServices practicesServices)
        {
            _practicesServices = practicesServices;
        }

        public async Task<Response> RunCodePractice(Request request)
        {
            if(request.runCodePractice.practiceId > 0 &&
              (request.runCodePractice.practiceCode != null && request.runCodePractice.practiceCode.Trim() != "") &&
              request.runCodePractice.codeLanguageId > 0)
            {
                var response = await _practicesServices.RunCodePractice(request);
                return response;
            }

            return new Response(null, "Request error", "The fields are not allowed to be null", null);
        }
    }
}
