using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface ICourseCommentActionsServices
    {
        Task CreateNewCourseCommentAction(CourseCommentActions courseCommentAction);

        Task UpdateCourseCommentAction(CourseCommentActions courseCommentAction);

        Task<IEnumerable<CourseCommentActions>> GetAllCourseCommentActions();
    }
}
