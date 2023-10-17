using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Practices.IGetPracticeLevelsFunction;

namespace learn_programming_services.Businesses.Functions.Practices
{
    public class GetPracticeLevelsFunction : IGetPracticeLevelsFunction
    {
        private readonly IPracticeLevelsServices _practiceLevelsServices;

        public GetPracticeLevelsFunction(IPracticeLevelsServices practiceLevelsServices)
        {
            _practiceLevelsServices = practiceLevelsServices;
        }

        public async Task<Response> GetPracticeLevels()
        {
            var response = await _practiceLevelsServices.GetPracticeLevels();
            return response;
        }
    }
}
