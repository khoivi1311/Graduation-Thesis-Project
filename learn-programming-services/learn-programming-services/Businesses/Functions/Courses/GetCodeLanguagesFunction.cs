using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IGetCodeLanguagesFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class GetCodeLanguagesFunction : IGetCodeLanguagesFunction
    {
        private readonly ICodeLanguagesServices _codeLanguagesServices;
        
        public GetCodeLanguagesFunction(ICodeLanguagesServices codeLanguagesServices)
        {
            _codeLanguagesServices = codeLanguagesServices;
        }

        public async Task<Response> GetCodeLanguages()
        {
            var response = await _codeLanguagesServices.GetCodeLanguages();
            return response;
        }
    }
}
