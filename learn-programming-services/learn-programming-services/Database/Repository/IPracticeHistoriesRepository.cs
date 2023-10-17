using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface IPracticeHistoriesRepository
    {
        Task<IEnumerable<PracticeHistories>> getAllPracticeHistories();

        Task<IEnumerable<PracticeHistories>> findPracticeHistoriesByPracticeId(int practiceId);

        Task<IEnumerable<PracticeHistories>> findPracticeHistoriesByUserIdAndPracticeId(int userId, int practiceId);

        Task createNewPracticeHistory(PracticeHistories practiceHistory);
    }
}
