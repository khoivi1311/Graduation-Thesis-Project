using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface ICourseCommentsRepository
    {
        Task createNewCourseComment(CourseComments courseComment);

        Task<CourseComments> findCourseCommentById(int id);

        Task<IEnumerable<CourseComments>> getAllCourseComments();

        Task updateCourseComment(CourseComments courseComment);
    }
}
