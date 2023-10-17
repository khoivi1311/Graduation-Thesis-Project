namespace learn_programming_services.Businesses.Functions.Practices
{
    public interface IGetPracticeHistoriesFunction
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
            public List<PracticeHistory> practiceHistories { get; set; }

            public Response(List<PracticeHistory> practiceHistories)
            {
                this.practiceHistories = practiceHistories;
            }
        }

        public class PracticeHistory
        {
            public int historyId { get; set; }

            public DateTime submittedDate { get; set; }

            public int codeLanguageId { get; set; }

            public string codeLanguageName { get; set; }

            public string codeLanguageVersion { get; set; }

            public string codeSubmitted { get; set; }

            public string testCase { get; set; }

            public int score { get; set; }

            public string userSubmitted { get; set; }
        }

        Task<Response> GetPracticeHistories(Request request);
    }
}
