using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface ICourseReplyCommentActionsServices
    {
        Task CreateNewCourseReplyCommentAction(CourseReplyCommentActions courseReplyCommentAction);

        Task UpdateCourseReplyCommentAction(CourseReplyCommentActions courseReplyCommentActions);

        Task<IEnumerable<CourseReplyCommentActions>> GetAllCourseReplyCommentActions();
    }
}
