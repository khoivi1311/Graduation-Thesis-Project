using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Practices.IDeletePracticeTestCaseFunction;

namespace learn_programming_services.Businesses.Functions.Practices
{
    public class DeletePracticeTestCaseFunction : IDeletePracticeTestCaseFunction
    {
        private readonly IPracticeTestCasesServices _practiceTestCasesServices;

        public DeletePracticeTestCaseFunction(IPracticeTestCasesServices practiceTestCasesServices)
        {
            _practiceTestCasesServices = practiceTestCasesServices;
        }

        public async Task<Response> DeletePracticeTestCase(Request request)
        {
            var response = await _practiceTestCasesServices.DeletePracticeTestCase(request);
            return response;
        }
    }
}
