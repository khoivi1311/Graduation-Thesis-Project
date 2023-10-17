using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IGetThemesFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class GetThemesFunction : IGetThemesFunction
    {
        private readonly IThemesServices _themesServices;

        public GetThemesFunction(IThemesServices themesServices)
        {
            _themesServices = themesServices;
        }

        public async Task<Response> GetThemes()
        {
            var response = await _themesServices.GetThemes();
            return response;
        }
    }
}
