using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Practices.IDeletePracticeFunction;

namespace learn_programming_services.Businesses.Functions.Practices
{
    public class DeletePracticeFunction : IDeletePracticeFunction
    {
        private readonly IPracticesServices _practicesServices;

        public DeletePracticeFunction(IPracticesServices practicesServices)
        {
            _practicesServices = practicesServices;
        }

        public async Task<Response> DeletePractice(Request request)
        {
            var response = await _practicesServices.DeletePractice(request);
            return response;
        }
    }
}
