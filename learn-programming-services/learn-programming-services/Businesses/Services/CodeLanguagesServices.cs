using learn_programming_services.Businesses.Functions.Courses;
using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class CodeLanguagesServices : ICodeLanguagesServices
    {
        private readonly ICodeLanguagesRepository _codeLanguagesRepository;

        public CodeLanguagesServices(ICodeLanguagesRepository codeLanguagesRepository)
        {
            _codeLanguagesRepository = codeLanguagesRepository;
        }

        public async Task<IEnumerable<CodeLanguages>> GetAllCodeLanguages()
        {
            return await _codeLanguagesRepository.getAllCodeLanguages();
        }

        public async Task<CodeLanguages> FindCodeLanguageById(int id)
        {
            return await _codeLanguagesRepository.findCodeLanguageById(id);
        }

        public async Task<IGetCodeLanguagesFunction.Response> GetCodeLanguages()
        {
            var codeLanguages = await _codeLanguagesRepository.getAllCodeLanguages();

            List<IGetCodeLanguagesFunction.CodeLanguage> codeLanguagesList = new List<IGetCodeLanguagesFunction.CodeLanguage>();

            if (codeLanguages != null && codeLanguages.Count() > 0)
            {
                foreach(var codeLanguage in codeLanguages)
                {
                    IGetCodeLanguagesFunction.CodeLanguage data = new IGetCodeLanguagesFunction.CodeLanguage()
                    {
                        codeLanguageId = codeLanguage.Id,
                        codeLanguageName = codeLanguage.Name,
                        codeLanguageVersion = codeLanguage.Version,
                    };

                    codeLanguagesList.Add(data);
                }
            }

            return new IGetCodeLanguagesFunction.Response(codeLanguagesList);
        }
    }
}
