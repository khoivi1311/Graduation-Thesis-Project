using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface ICodeLanguagesRepository
    {
        Task<IEnumerable<CodeLanguages>> getAllCodeLanguages();

        Task<CodeLanguages> findCodeLanguageById(int id);
    }
}
