namespace learn_programming_services.Businesses.Functions.Practices
{
    public interface IGetPracticeDetailsManagementFunction
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
            public int practiceId { get; set; }

            public string practiceName { get; set; }

            public string content { get; set; }

            public int score { get; set; }

            public int practiceLevelId { get; set; }

            public int totalTestCases { get; set; }

            public List<TestCase> testCases { get; set; }

            public int totalHiddenTestCases { get; set; }

            public List<TestCase> hiddenTestCases { get; set; }

            public Response(int practiceId, string practiceName, string content, int score, int practiceLevelId, int totalTestCases, List<TestCase> testCases, int totalHiddenTestCases, List<TestCase> hiddenTestCases)
            {
                this.practiceId = practiceId;
                this.practiceName = practiceName;
                this.content = content;
                this.score = score;
                this.practiceLevelId = practiceLevelId;
                this.totalTestCases = totalTestCases;
                this.testCases = testCases;
                this.totalHiddenTestCases = totalHiddenTestCases;
                this.hiddenTestCases = hiddenTestCases;
            }

            public Response()
            {
                this.practiceId = 0;
                this.practiceName = null;
                this.content = null;
                this.score = 0;
                this.practiceLevelId = 0;
                this.totalTestCases = 0;
                this.testCases = null;
                this.totalHiddenTestCases = 0;
                this.hiddenTestCases = null;
            }
        }

        public class TestCase
        {
            public int testCaseId { get; set; }

            public string input { get; set; }

            public string expectedOutput { get; set; }

            public bool isHidden { get; set; }
        }

        Task<Response> GetPracticeDetailsManagement(Request request);
    }
}
