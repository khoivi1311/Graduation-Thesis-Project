using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface ILessonCommentActionsRepository
    {
        Task createNewLessonCommentAction(LessonCommentActions lessonCommentAction);

        Task<IEnumerable<LessonCommentActions>> getAllLessonCommentActions();

        Task updateLessonCommentAction(LessonCommentActions lessonCommentAction);
    }
}
