using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class CourseVotesServices : ICourseVotesServices
    {
        private readonly ICourseVotesRepository _courseVotesRepository;

        public CourseVotesServices(ICourseVotesRepository courseVotesRepository)
        {
            _courseVotesRepository = courseVotesRepository;
        }

        public async Task<IEnumerable<CourseVotes>> GetAllCourseVotes()
        {
            return await _courseVotesRepository.getAllCourseVotes();
        }
    }
}
