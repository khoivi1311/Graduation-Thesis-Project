namespace learn_programming_services.Businesses.Functions.Discussions
{
    public interface IDeleteDiscussionFunction
    {
        public class Request
        {
            public int userId { get; set; }

            public int discussionId { get; set; }

            public Request(int userId, int discussionId)
            {
                this.userId = userId;
                this.discussionId = discussionId;
            }
        }

        public class Response
        {
            public bool isSuccessful { get; set; }

            public string errorMessages { get; set; }

            public Response(bool isSuccessful, string errorMessages)
            {
                this.isSuccessful = isSuccessful;
                this.errorMessages = errorMessages;
            }
        }

        Task<Response> DeleteDiscussion(Request request);
    }
}
