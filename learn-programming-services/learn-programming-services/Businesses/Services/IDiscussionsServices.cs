using learn_programming_services.Businesses.Functions.Discussions;

namespace learn_programming_services.Businesses.Services
{
    public interface IDiscussionsServices
    {
        Task<ICreateNewDiscussionFunction.Response> CreateNewDiscussion(ICreateNewDiscussionFunction.Request request);

        Task<ICreateNewDiscussionCommentFunction.Response> CreateNewDiscussionComment(ICreateNewDiscussionCommentFunction.Request request);

        Task<ICreateNewDiscussionReplyCommentFunction.Response> CreateNewDiscussionReplyComment(ICreateNewDiscussionReplyCommentFunction.Request request);

        Task<IDeleteDiscussionFunction.Response> DeleteDiscussion(IDeleteDiscussionFunction.Request request);

        Task<IDeleteDiscussionCommentFunction.Response> DeleteDiscussionComment(IDeleteDiscussionCommentFunction.Request request);

        Task<IDeleteDiscussionReplyCommentFunction.Response> DeleteDiscussionReplyComment(IDeleteDiscussionReplyCommentFunction.Request request);

        Task<IDiscussionCommentActionFunction.Response> DiscussionCommentAction(IDiscussionCommentActionFunction.Request request);

        Task<IDiscussionReplyCommentActionFunction.Response> DiscussionReplyCommentAction(IDiscussionReplyCommentActionFunction.Request request);

        Task<IGetDiscussionsFunction.Response> GetDiscussions(IGetDiscussionsFunction.Request request);

        Task<IGetDiscussionDetailsFunction.Response> GetDiscussionDetails(IGetDiscussionDetailsFunction.Request request);
    }
}
