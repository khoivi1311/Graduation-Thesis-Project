using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface IPracticesRepository
    {
        Task createNewPractice(Practices practice);

        Task<Practices> findLatestPractice();

        Task<IEnumerable<Practices>> getAllPractices();

        Task<IEnumerable<Practices>> findPracticeByUserId(int userId);

        Task<Practices> findPracticeById(int id);

        Task updatePractice(Practices practice);
    }
}
