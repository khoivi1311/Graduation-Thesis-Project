using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Discussions.ICreateNewDiscussionFunction;

namespace learn_programming_services.Businesses.Functions.Discussions
{
    public class CreateNewDiscussionFunction : ICreateNewDiscussionFunction
    {
        private readonly IDiscussionsServices _discussionsServices;

        public CreateNewDiscussionFunction(IDiscussionsServices discussionsServices)
        {
            _discussionsServices = discussionsServices;
        }

        public async Task<Response> CreateNewDiscussion(Request request)
        {
            if(request.discussion.userId > 0 && 
              (request.discussion.discussionName != null && request.discussion.discussionName.Trim() != "") &&
              (request.discussion.description != null && request.discussion.description.Trim() != "") &&
              (request.discussion.content != null && request.discussion.content.Trim() != "") &&
              (request.discussion.image != null && request.discussion.image.Trim() != ""))
            {
                var response = await _discussionsServices.CreateNewDiscussion(request);
                return response;
            }

            return new Response(false, "The fields are not allowed to be null");
        }
    }
}
