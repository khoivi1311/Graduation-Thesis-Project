using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface ILessonHistoriesRepository
    {
        Task<IEnumerable<LessonHistories>> findLessonHistoryByUserIdAndLessonId(int userId, int lessonId);

        Task createNewLessonHistory(LessonHistories lessonHistory);

        Task<IEnumerable<LessonHistories>> findLessonHistoryByLessonId(int lessonId);
    }
}
