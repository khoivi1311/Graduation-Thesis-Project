using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Practices.ISubmitCodePracticeFunction;

namespace learn_programming_services.Businesses.Functions.Practices
{
    public class SubmitCodePracticeFunction : ISubmitCodePracticeFunction
    {
        private readonly IPracticesServices _practicesServices;

        public SubmitCodePracticeFunction(IPracticesServices practicesServices)
        {
            _practicesServices = practicesServices;
        }

        public async Task<Response> SubmitCodePractice(Request request)
        {
            if (request.submitCodePractice.practiceId > 0 &&
              (request.submitCodePractice.practiceCode != null && request.submitCodePractice.practiceCode.Trim() != "") &&
              request.submitCodePractice.codeLanguageId > 0 && request.submitCodePractice.userId > 0)
            {
                var response = await _practicesServices.SubmitCodePractice(request);
                return response;
            }

            return new Response(null, null, null, 0);
        }
    }
}
