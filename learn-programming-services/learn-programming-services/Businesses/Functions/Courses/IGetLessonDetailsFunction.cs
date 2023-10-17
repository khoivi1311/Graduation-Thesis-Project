namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface IGetLessonDetailsFunction
    {
        public class Request
        {
            public int userId { get; set; }

            public int lessonId { get; set; }

            public Request(int userId, int lessonId)
            {
                this.userId = userId;
                this.lessonId = lessonId;
            }
        }

        public class Response
        {
            public int lessonId { get; set; }

            public string lessonName { get; set; }

            public string content { get; set; }

            public int score { get; set; }

            public string chapterName { get; set; }

            public string authorName { get; set; }

            public List<TestCase> testCases { get; set; }

            public List<CodeSample> codeSamples { get; set; }

            public Response(int lessonId, string lessonName, string content, int score, string chapterName, string authorName, List<TestCase> testCases, List<CodeSample> codeSamples)
            {
                this.lessonId = lessonId;
                this.lessonName = lessonName;
                this.content = content;
                this.score = score;
                this.chapterName = chapterName;
                this.authorName = authorName;
                this.testCases = testCases;
                this.codeSamples = codeSamples;
            }

            public Response()
            {
                this.lessonId = 0;
                this.lessonName = null;
                this.content = null;
                this.score = 0;
                this.chapterName = null;
                this.authorName = null;
                this.testCases = null;
                this.codeSamples = null;
            }
        }

        public class TestCase
        {
            public int testCaseId { get; set; }

            public string input { get; set; }

            public string expectedOutput { get; set; }

            public bool isHidden { get; set; }
        }

        public class CodeSample
        {
            public string codeSample { get; set; }

            public int codeLanguageId { get; set; }

            public string codeLanguageName { get; set; }

            public string codeLanguageVersion { get; set; }

            public bool isSubmitted { get; set; }
        }

        Task<Response> GetLessonDetails(Request request);
    }
}
