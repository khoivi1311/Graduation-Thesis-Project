using learn_programming_services.Businesses.Functions.Courses;
using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface ILessonReplyCommentActionsServices
    {
        Task<IEnumerable<LessonReplyCommentActions>> GetAllLessonReplyCommentActions();

        Task UpdateLessonReplyCommentAction(LessonReplyCommentActions lessonReplyCommentAction);

        Task CreateNewLessonReplyCommentAction(LessonReplyCommentActions lessonReplyCommentAction);
    }
}
