using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface ICourseLevelsRepository
    {
        Task<IEnumerable<CourseLevels>> getAllCourseLevels();

        Task<CourseLevels> findCourseLevelById(int id);
    }
}
