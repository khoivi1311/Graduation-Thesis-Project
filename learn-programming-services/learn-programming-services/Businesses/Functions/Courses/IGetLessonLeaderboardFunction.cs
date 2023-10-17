namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface IGetLessonLeaderboardFunction
    {
        public class Request
        {
            public int lessonId { get; set; }

            public int pageSize { get; set; }
            
            public int pageNumber { get; set; }

            public Request(int lessonId, int pageSize, int pageNumber)
            {
                this.lessonId = lessonId;
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

        Task<Response> GetLessonLeaderboard(Request request);
    }
}
