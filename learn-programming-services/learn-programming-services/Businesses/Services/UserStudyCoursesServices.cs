using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class UserStudyCoursesServices : IUserStudyCoursesServices
    {
        private readonly IUserStudyCoursesRepository _userStudyCoursesRepository;

        public UserStudyCoursesServices(IUserStudyCoursesRepository userStudyCoursesRepository)
        {
            _userStudyCoursesRepository = userStudyCoursesRepository;
        }

        public async Task<IEnumerable<UserStudyCourses>> GetAllUserStudyCourses()
        {
            return await _userStudyCoursesRepository.getAllUserStudyCourses();
        }

        public async Task CreateNewUserStudyCourse(UserStudyCourses userStudyCourse)
        {
            await _userStudyCoursesRepository.createNewUserStudyCourse(userStudyCourse);
        }

        public async Task<UserStudyCourses> FindUserStudyCourseByCourseIdAndUserId(int courseId, int userId)
        {
            return await _userStudyCoursesRepository.findUserStudyCourseByCourseIdAndUserId(courseId, userId);
        }

        public async Task UpdateUserStudyCourse(UserStudyCourses userStudyCourse)
        {
            await _userStudyCoursesRepository.updateUserStudyCourse(userStudyCourse);
        }
    }
}
