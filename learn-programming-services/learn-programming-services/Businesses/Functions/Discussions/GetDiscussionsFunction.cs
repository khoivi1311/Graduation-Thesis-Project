using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Discussions.IGetDiscussionsFunction;

namespace learn_programming_services.Businesses.Functions.Discussions
{
    public class GetDiscussionsFunction : IGetDiscussionsFunction
    {
        private readonly IDiscussionsServices _discussionsServices;

        public GetDiscussionsFunction(IDiscussionsServices discussionsServices)
        {
            _discussionsServices = discussionsServices;
        }

        public async Task<Response> GetDiscussions(Request request)
        {
            if(request.pageSize > 0 && request.pageNumber > 0)
            {
                var response = await _discussionsServices.GetDiscussions(request);
                return response;
            }

            return new Response(0, null);
        }
    }
}
