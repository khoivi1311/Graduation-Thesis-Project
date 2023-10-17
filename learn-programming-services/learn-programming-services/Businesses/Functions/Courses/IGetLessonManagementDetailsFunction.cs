namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface IGetLessonManagementDetailsFunction
    {
        public class Request
        {
            public int id { get; set; }

            public Request(int id) 
            { 
                this.id = id;
            }
        }

        public class Response
        {
            public int lessonId { get; set; }

            public string lessonName { get; set; }

            public string content { get; set; }

            public int score { get; set; }

            public int chapterId { get; set; }

            public int totalTestCases { get; set; }

            public List<TestCase> testCases { get; set; }

            public int totalHiddenTestCases { get; set; }

            public List<TestCase> hiddenTestCases { get; set; }

            public List<CodeSample> codeSamples { get; set; }

            public Response(int lessonId, string lessonName, string content, int score, int chapterId, int totalTestCases, List<TestCase> testCases, int totalHiddenTestCases, List<TestCase> hiddenTestCases,  List<CodeSample> codeSamples)
            {
                this.lessonId = lessonId;
                this.lessonName = lessonName;
                this.content = content;
                this.score = score;
                this.chapterId = chapterId;
                this.totalTestCases = totalTestCases;
                this.testCases = testCases;
                this.totalHiddenTestCases = totalHiddenTestCases;
                this.hiddenTestCases = hiddenTestCases;
                this.codeSamples = codeSamples;
            }

            public Response()
            {
                this.lessonId = 0;
                this.lessonName = null;
                this.content = null;
                this.score = 0;
                this.chapterId = 0;
                this.totalTestCases = 0;
                this.testCases = null;
                this.totalHiddenTestCases = 0;
                this.hiddenTestCases = null;
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
            public int codeSampleId { get; set; }

            public string codeSample { get; set; }

            public int codeLanguageId { get; set; }
        }

        Task<Response> GetLessonManagementDetails(Request request);
    }
}
