using learn_programming_services.Businesses.Functions.Practices;
using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface IPracticeHistoriesServices
    {
        Task<IEnumerable<PracticeHistories>> GetAllPracticeHistories();

        Task<IEnumerable<PracticeHistories>> FindPracticeHistoriesByPracticeId(int practiceId);

        Task<IEnumerable<PracticeHistories>> FindPracticeHistoriesByUserIdAndPracticeId(int userId, int practiceId);

        Task CreateNewPracticeHistory(PracticeHistories practiceHistory);

        Task<IGetPracticeHistoriesFunction.Response> GetPracticeHistories(IGetPracticeHistoriesFunction.Request request);

        Task<IGetPracticeLeaderboardFunction.Response> GetPracticeLeaderboard(IGetPracticeLeaderboardFunction.Request request);
    }
}
