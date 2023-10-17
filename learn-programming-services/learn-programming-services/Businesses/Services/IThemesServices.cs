using learn_programming_services.Businesses.Functions.Courses;

namespace learn_programming_services.Businesses.Services
{
    public interface IThemesServices
    {
        Task<IGetThemesFunction.Response> GetThemes();
    }
}
