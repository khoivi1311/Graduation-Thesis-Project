using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Discussions.IGetDiscussionDetailsFunction;

namespace learn_programming_services.Businesses.Functions.Discussions
{
    public class GetDiscussionDetailsFunction : IGetDiscussionDetailsFunction
    {
        private readonly IDiscussionsServices _discussionsServices;

        public GetDiscussionDetailsFunction(IDiscussionsServices discussionsServices)
        {
            _discussionsServices = discussionsServices;
        }

        public async Task<Response> GetDiscussionDetails(Request request)
        {
            if (request.discussionId > 0 && request.userId > 0)
            {
                var response = await _discussionsServices.GetDiscussionDetails(request);
                return response;
            }

            return new Response();
        }
    }
}
