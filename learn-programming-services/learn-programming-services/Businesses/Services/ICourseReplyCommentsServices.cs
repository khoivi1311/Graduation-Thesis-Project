using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface ICourseReplyCommentsServices
    {
        Task CreateNewCourseReplyComment(CourseReplyComments courseReplyComment);

        Task<IEnumerable<CourseReplyComments>> GetAllCourseReplyComments();

        Task<CourseReplyComments> FindCourseReplyCommentById(int id);

        Task UpdateCourseReplyComment(CourseReplyComments courseReplyComment);
    }
}
