using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Discussions.IDeleteDiscussionFunction;

namespace learn_programming_services.Businesses.Functions.Discussions
{
    public class DeleteDiscussionFunction : IDeleteDiscussionFunction
    {
        private readonly IDiscussionsServices _discussionsServices;

        public DeleteDiscussionFunction(IDiscussionsServices discussionsServices)
        {
            _discussionsServices = discussionsServices;
        }

        public async Task<Response> DeleteDiscussion(Request request)
        {
            var response = await _discussionsServices.DeleteDiscussion(request);
            return response;
        }
    }
}
