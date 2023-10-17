namespace learn_programming_services.Businesses.Functions.Practices
{
    public interface IGetPracticeDetailsFunction
    {
        public class Request
        {
            public int practiceId { get; set; }

            public int userId { get; set; }

            public Request(int practiceId, int userId)
            {
                this.practiceId = practiceId;
                this.userId = userId;
            }
        }

        public class Response
        {
            public int practiceId { get; set; }

            public string practiceName { get; set; }

            public string content { get; set; }

            public string level { get; set; }

            public int score { get; set; }

            public string author { get; set; }

            public int codeLanguageId { get; set; }

            public string codeSubmitted { get; set; }

            public List<TestCase> testCases { get; set; }

            public Response(int practiceId, string practiceName, string content, string level, int score, string author, int codeLanguageId, string codeSubmitted, List<TestCase> testCases)
            {
                this.practiceId = practiceId;
                this.practiceName = practiceName;
                this.content = content;
                this.level = level;
                this.score = score;
                this.author = author;
                this.codeLanguageId = codeLanguageId;
                this.codeSubmitted = codeSubmitted;
                this.testCases = testCases;
            }

            public Response() 
            {
                this.practiceId = 0;
                this.practiceName = null;
                this.content = null;
                this.level = null;
                this.score = 0;
                this.author = null;
                this.codeLanguageId = 0;
                this.codeSubmitted = null;
                this.testCases = null;
            }
        }

        public class TestCase
        {
            public int testCaseId { get; set; }

            public string input { get; set; }

            public string expectedOutput { get; set; }

            public bool isHidden { get; set; }
        }

        Task<Response> GetPracticeDetails(Request request);
    }
}
