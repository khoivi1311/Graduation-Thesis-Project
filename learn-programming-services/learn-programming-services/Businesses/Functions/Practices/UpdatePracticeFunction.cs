using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Practices.IUpdatePracticeFunction;

namespace learn_programming_services.Businesses.Functions.Practices
{
    public class UpdatePracticeFunction : IUpdatePracticeFunction
    {
        private readonly IPracticesServices _practicesServices;

        public UpdatePracticeFunction(IPracticesServices practicesServices)
        {
            _practicesServices = practicesServices;
        }

        public async Task<Response> UpdatePractice(Request request)
        {
            if (request.practice.practiceId > 0 &&
               (request.practice.practiceName != null && request.practice.practiceName.Trim() != "") &&
               (request.practice.content != null && request.practice.content.Trim() != "") &&
               (request.practice.score > 0) &&
               (request.practice.practiceLevelId > 0) &&
               (request.practice.testCases != null && request.practice.testCases.Count() > 0))
            {
                var response = await _practicesServices.UpdatePractice(request);
                return response;
            }

            return new Response(false, "The fields are not allowed to be null");
        }
    }
}
