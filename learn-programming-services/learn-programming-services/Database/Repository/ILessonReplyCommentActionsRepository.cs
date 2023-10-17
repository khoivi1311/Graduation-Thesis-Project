using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface ILessonReplyCommentActionsRepository
    {
        Task createNewLessonReplyCommentAction(LessonReplyCommentActions lessonReplyCommentAction);

        Task<IEnumerable<LessonReplyCommentActions>> getAllLessonReplyCommentActions();

        Task updateLessonReplyCommentAction(LessonReplyCommentActions lessonReplyCommentAction);
    }
}
