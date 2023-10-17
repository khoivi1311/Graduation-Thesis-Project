using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface ILessonReplyCommentsServices
    {
        Task<IEnumerable<LessonReplyComments>> GetAllLessonReplyComments();

        Task<LessonReplyComments> FindLessonReplyCommentById(int id);

        Task CreateNewLessonReplyComment(LessonReplyComments lessonReplyComment);

        Task UpdateLessonReplyComment(LessonReplyComments lessonReplyComment);
    }
}
