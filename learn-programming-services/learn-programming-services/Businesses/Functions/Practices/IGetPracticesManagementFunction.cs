namespace learn_programming_services.Businesses.Functions.Practices
{
    public interface IGetPracticesManagementFunction
    {
        public class Request
        {
            public int userId { get; set; }

            public int pageSize { get; set; }

            public int pageNumber { get; set; }

            public string? keyword { get; set; }

            public Request(int userId, int pageSize, int pageNumber, string? keyword)
            {
                this.userId = userId;
                this.pageSize = pageSize;
                this.pageNumber = pageNumber;
                this.keyword = keyword;
            }
        }

        public class Response
        {
            public int totalPages { get; set; }

            public List<PracticeManagement> practices { get; set; }

            public Response(int totalPages, List<PracticeManagement> practices)
            {
                this.totalPages = totalPages;
                this.practices = practices;
            }
        }

        public class PracticeManagement
        {
            public int practiceId { get; set; }

            public string practiceName { get; set; }

            public int score { get; set; }

            public string practiceLevel { get; set; }

            public string authorName { get; set; }

            public bool isHidden { get; set; }

            public DateTime createDate { get; set; }

            public DateTime updateDate { get; set; }
        }

        Task<Response> GetPracticesManagement(Request request);
    }
}
