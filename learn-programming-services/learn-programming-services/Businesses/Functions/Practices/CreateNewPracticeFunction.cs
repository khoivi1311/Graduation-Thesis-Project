using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Practices.ICreateNewPracticeFunction;

namespace learn_programming_services.Businesses.Functions.Practices
{
    public class CreateNewPracticeFunction : ICreateNewPracticeFunction
    {
        private readonly IPracticesServices _practicesServices;

        public CreateNewPracticeFunction(IPracticesServices practicesServices)
        {
            _practicesServices = practicesServices;
        }

        public async Task<Response> CreateNewPractice(Request request)
        {
            List<string> errors = new List<string>();

            if ((request.newPractice.practiceName != null && request.newPractice.practiceName.Trim() != "") &&
               (request.newPractice.content != null && request.newPractice.content.Trim() != "") &&
               (request.newPractice.score > 0) &&
               (request.newPractice.practiceLevelId > 0) &&
               (request.newPractice.authorId > 0) &&
               (request.newPractice.testCases != null && request.newPractice.testCases.Count() > 0))
            {
                foreach(var testCase in  request.newPractice.testCases)
                {
                    if ((testCase.input == null || testCase.input.Trim() == "") ||
                       (testCase.expectedOutput == null || testCase.expectedOutput.Trim() == ""))
                    {
                        errors.Add("The test case have input: " + testCase.input.Trim() + " and expected output: " + testCase.expectedOutput + " invalid");
                    }
                }

                if (errors.Count > 0)
                {
                    return new Response(false, errors);
                }

                var response = await _practicesServices.CreateNewPractice(request);
                return response;
            }

            errors.Add("The fields are not allowed to be null");
            return new Response(false, errors);
        }
    }
}
