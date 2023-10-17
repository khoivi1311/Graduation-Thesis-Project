using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class CourseLevelsServices : ICourseLevelsServices
    {
        private readonly ICourseLevelsRepository _courseLevelsRepository;

        public CourseLevelsServices(ICourseLevelsRepository courseLevelsRepository)
        {
            _courseLevelsRepository = courseLevelsRepository;
        }

        public async Task<IEnumerable<CourseLevels>> GetAllCourseLevels()
        {
            return await _courseLevelsRepository.getAllCourseLevels();
        }

        public async Task<CourseLevels> FindCourseLevelById(int id)
        {
            return await _courseLevelsRepository.findCourseLevelById(id);
        }
    }
}
