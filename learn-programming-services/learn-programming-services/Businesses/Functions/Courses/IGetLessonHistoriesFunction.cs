namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface IGetLessonHistoriesFunction
    {
        public class Request
        {
            public int lessonId { get; set; }

            public int userId { get; set; }

            public Request(int lessonId, int userId)
            {
                this.lessonId = lessonId;
                this.userId = userId;
            }
        }

        public class Response
        {
            public List<LessonHistory> lessonHistories { get; set; }

            public Response(List<LessonHistory> lessonHistories)
            {
                this.lessonHistories = lessonHistories;
            }
        }

        public class LessonHistory
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

        Task<Response> GetLessonHistories(Request request);
    }
}
