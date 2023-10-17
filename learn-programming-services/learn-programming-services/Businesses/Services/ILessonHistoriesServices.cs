using learn_programming_services.Businesses.Functions.Courses;
using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface ILessonHistoriesServices
    {
        Task<IEnumerable<LessonHistories>> FindLessonHistoryByUserIdAndLessonId(int userId, int lessonId);

        Task CreateNewLessonHistory(LessonHistories lessonHistory);

        Task<IGetLessonHistoriesFunction.Response> GetLessonHistories(IGetLessonHistoriesFunction.Request request);

        Task<IGetLessonLeaderboardFunction.Response> GetLessonLeaderboard(IGetLessonLeaderboardFunction.Request request);
    }
}
