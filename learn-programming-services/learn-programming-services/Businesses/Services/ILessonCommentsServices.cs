using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface ILessonCommentsServices
    {
        Task CreateNewLessonComment(LessonComments lessonComment);

        Task UpdateLessonComment(LessonComments lessonComment);

        Task<LessonComments> FindLessonCommentById(int id);

        Task<IEnumerable<LessonComments>> GetAllLessonComments();
    }
}
