using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface ILessonReplyCommentsRepository
    {
        Task createNewLessonReplyComment(LessonReplyComments lessonReplyComment);

        Task<IEnumerable<LessonReplyComments>> getAllLessonReplyComments();

        Task<LessonReplyComments> findLessonReplyCommentById(int id);

        Task updateLessonReplyComment(LessonReplyComments lessonReplyComment);
    }
}
