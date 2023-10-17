using learn_programming_services.Apis.Discussions.Dtos;

namespace learn_programming_services.Businesses.Functions.Discussions
{
    public interface ICreateNewDiscussionFunction
    {
        public class Request
        {
            public CreateNewDiscussionDto discussion { get; set; }

            public Request(CreateNewDiscussionDto discussion)
            {
                this.discussion = discussion;
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

        Task<Response> CreateNewDiscussion(Request request);
    }
}
