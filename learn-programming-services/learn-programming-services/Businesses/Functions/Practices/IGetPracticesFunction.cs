namespace learn_programming_services.Businesses.Functions.Practices
{
    public interface IGetPracticesFunction
    {
        public class Request
        {
            public int userId { get; set; }

            public int pageSize { get; set; }

            public int pageNumber { get; set; }

            public string? keyword { get; set; }

            public int? levelId { get; set; }

            public bool? isCompleted { get; set; }

            public Request(int userId, int pageSize, int pageNumber, string? keyword, int? levelId, bool? isCompleted)
            {
                this.userId = userId;
                this.pageSize = pageSize;
                this.pageNumber = pageNumber;
                this.keyword = keyword;
                this.levelId = levelId;
                this.isCompleted = isCompleted;
            }
        }

        public class Response
        {
            public int totalPages { get; set; }

            public List<Practice> practices { get; set; }

            public Response(int totalPages, List<Practice> practices)
            {
                this.totalPages = totalPages;
                this.practices = practices;
            }
        }

        public class Practice
        {
            public int practiceId { get; set; }

            public string practiceName { get; set; }

            public string level { get; set; }

            public int score { get; set; }

            public string author { get; set; }

            public int numberOfParticipants { get; set; }

            public bool isCompleted { get; set; }
        }

        Task<Response> GetPractices(Request request);
    }
}
