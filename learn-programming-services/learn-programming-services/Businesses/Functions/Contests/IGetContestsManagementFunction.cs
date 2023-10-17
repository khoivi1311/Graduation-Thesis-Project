namespace learn_programming_services.Businesses.Functions.Contests
{
    public interface IGetContestsManagementFunction
    {
        public class Request
        {
            public int userId { get; set; }

            public string? keyword { get; set; }

            public Request(int userId, string? keyword)
            {
                this.userId = userId;
                this.keyword = keyword;
            }
        }

        public class Response
        {
            public List<ContestManagement> contests { get; set; }

            public Response(List<ContestManagement> contests)
            {
                this.contests = contests;
            }
        }

        public class ContestManagement
        {
            public int contestId { get; set; }

            public string name { get; set; }

            public string description { get; set; }

            public string information { get; set; }

            public string location { get; set; }

            public int statusId { get; set; }

            public string authorName { get; set; }

            public DateTime startTime { get; set; }

            public DateTime endTime { get; set; }

            public bool isHidden { get; set; }
        }

        Task<Response> GetContestsManagement(Request request);
    }
}
