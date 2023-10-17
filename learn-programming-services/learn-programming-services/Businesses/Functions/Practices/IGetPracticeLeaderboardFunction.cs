namespace learn_programming_services.Businesses.Functions.Practices
{
    public interface IGetPracticeLeaderboardFunction
    {
        public class Request
        {
            public int practiceId { get; set; }

            public int pageSize { get; set; }

            public int pageNumber { get; set; }

            public Request(int practiceId, int pageSize, int pageNumber)
            {
                this.practiceId = practiceId;
                this.pageSize = pageSize;
                this.pageNumber = pageNumber;
            }
        }

        public class Response
        {
            public int totalPages { get; set; }

            public List<Leaderboard> leaderboards { get; set; }

            public Response(int totalPages, List<Leaderboard> leaderboards)
            {
                this.totalPages = totalPages;
                this.leaderboards = leaderboards;
            }
        }

        public class Leaderboard
        {
            public string authorName { get; set; }

            public string codeLanguageName { get; set; }

            public string codeLanguageVersion { get; set; }

            public int score { get; set; }

            public DateTime submittedDate { get; set; }
        }

        Task<Response> GetPracticeLeaderboard(Request request);
    }
}
