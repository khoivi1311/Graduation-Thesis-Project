using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface ICourseReplyCommentsRepository
    {
        Task createNewCourseReplyComment(CourseReplyComments courseReplyComment);

        Task<IEnumerable<CourseReplyComments>> getAllCourseReplyComments();

        Task<CourseReplyComments> findCourseReplyCommentById(int id);

        Task updateCourseReplyComment(CourseReplyComments courseReplyComment);
    }
}
