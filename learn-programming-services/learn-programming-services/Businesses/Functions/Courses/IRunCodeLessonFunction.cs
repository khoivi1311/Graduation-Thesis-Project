using learn_programming_services.Apis.Courses.Dtos;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface IRunCodeLessonFunction
    {
        public class Request
        {
            public RunCodeLessonDto runCodeLesson { get; set; }

            public Request(RunCodeLessonDto runCodeLesson)
            {
                this.runCodeLesson = runCodeLesson;
            }
        }

        public class Response
        {
            public string pass { get; set; }

            public string errorType { get; set; }

            public string errorMessage { get; set; }

            public List<TestCase> testCases { get; set; }

            public Response(string pass, string errorType, string errorMessage, List<TestCase> testCases)
            {
                this.pass = pass;
                this.errorType = errorType;
                this.errorMessage = errorMessage;
                this.testCases = testCases;
            }
        }

        public class TestCase
        {
            public int testCaseId { get; set; }

            public string actualOutput { get; set; }

            public bool isPassed { get; set; }
        }

        Task<Response> RunCodeLesson(Request request);
    }
}
