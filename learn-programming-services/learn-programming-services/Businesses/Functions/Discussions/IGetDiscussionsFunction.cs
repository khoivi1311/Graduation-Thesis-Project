namespace learn_programming_services.Businesses.Functions.Discussions
{
    public interface IGetDiscussionsFunction
    {
        public class Request
        {
            public int pageSize { get; set; }

            public int pageNumber { get; set; }

            public Request(int pageSize, int pageNumber)
            {
                this.pageSize = pageSize;
                this.pageNumber = pageNumber;
            }
        }

        public class Response
        {
            public int totalPages { get; set; }

            public List<Discussion> discussions { get; set; }

            public Response(int totalPages, List<Discussion> discussions)
            {
                this.totalPages = totalPages;
                this.discussions = discussions;
            }
        }

        public class Discussion
        {
            public int discussionId { get; set; }

            public string discussionName { get; set; }

            public string discussionDescription { get; set; }

            public string discussionImage { get; set; }

            public int totalComments { get; set; }

            public int authorId { get; set; }

            public string authorName { get; set; }

            public DateTime discussionDate { get; set; }
        }

        Task<Response> GetDiscussions(Request request);
    }
}
