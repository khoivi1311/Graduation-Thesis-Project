using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface IPracticeLevelsRepository
    {
        Task<IEnumerable<PracticeLevels>> getAllPracticeLevels();
    }
}
