namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface IGetCodeLanguagesFunction
    {
        public class Response
        {
            public List<CodeLanguage> codeLanguages { get; set; }

            public Response(List<CodeLanguage> codeLanguages) 
            {
                this.codeLanguages = codeLanguages;
            }
        }

        public class CodeLanguage
        {
            public int codeLanguageId { get; set; }

            public string codeLanguageName { get; set; }

            public string codeLanguageVersion { get; set; }
        }

        Task<Response> GetCodeLanguages();
    }
}
