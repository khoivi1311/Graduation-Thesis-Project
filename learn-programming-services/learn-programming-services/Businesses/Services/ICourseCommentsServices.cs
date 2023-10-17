using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface ICourseCommentsServices
    {
        Task CreateNewCourseComment(CourseComments courseComment);

        Task<CourseComments> FindCourseCommentById(int id);

        Task<IEnumerable<CourseComments>> GetAllCourseComments();

        Task UpdateCourseComment(CourseComments courseComment);
    }
}
