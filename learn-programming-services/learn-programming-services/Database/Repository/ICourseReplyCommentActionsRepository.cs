using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface ICourseReplyCommentActionsRepository
    {
        Task createNewCourseReplyCommentAction(CourseReplyCommentActions courseReplyCommentAction);

        Task updateCourseReplyCommentAction(CourseReplyCommentActions courseReplyCommentAction);

        Task<IEnumerable<CourseReplyCommentActions>> getAllCourseReplyCommentActions();
    }
}
