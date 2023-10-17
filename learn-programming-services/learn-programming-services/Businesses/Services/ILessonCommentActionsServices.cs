using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface ILessonCommentActionsServices
    {
        Task<IEnumerable<LessonCommentActions>> GetAllLessonCommentActions();

        Task UpdateLessonCommentAction(LessonCommentActions lessonCommentAction);

        Task CreateNewLessonCommentAction(LessonCommentActions lessonCommentAction);
    }
}
