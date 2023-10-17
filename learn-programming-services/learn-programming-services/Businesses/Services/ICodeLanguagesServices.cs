using learn_programming_services.Businesses.Functions.Courses;
using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface ICodeLanguagesServices
    {
        Task<IEnumerable<CodeLanguages>> GetAllCodeLanguages();

        Task<CodeLanguages> FindCodeLanguageById(int id);

        Task<IGetCodeLanguagesFunction.Response> GetCodeLanguages();
    }
}
