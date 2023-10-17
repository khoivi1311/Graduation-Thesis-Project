using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface ICourseCommentActionsRepository
    {
        Task createNewCourseCommentAction(CourseCommentActions courseCommentAction);

        Task updateCourseCommentAction(CourseCommentActions courseCommentAction);

        Task<IEnumerable<CourseCommentActions>> getAllCourseCommentActions();
    }
}
