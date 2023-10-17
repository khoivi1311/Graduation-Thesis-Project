using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface ICourseLevelsServices
    {
        Task<IEnumerable<CourseLevels>> GetAllCourseLevels();

        Task<CourseLevels> FindCourseLevelById(int id);
    }
}
