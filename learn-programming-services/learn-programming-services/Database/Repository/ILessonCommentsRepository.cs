using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface ILessonCommentsRepository
    {
        Task createNewLessonComment(LessonComments lessonComment);

        Task<LessonComments> findLessonCommentById(int id);

        Task<IEnumerable<LessonComments>> getAllLessonComments();

        Task updateLessonComment(LessonComments lessonComment);
    }
}
