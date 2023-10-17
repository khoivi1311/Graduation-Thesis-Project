using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class UserLearnedLessonsServices : IUserLearnedLessonsServices
    {
        private readonly IUserLearnedLessonsRepository _userLearnedLessonsRepository;

        public UserLearnedLessonsServices(IUserLearnedLessonsRepository userLearnedLessonsRepository)
        {
            _userLearnedLessonsRepository = userLearnedLessonsRepository;
        }

        public async Task<IEnumerable<UserLearnedLessons>> GetAllUserLearnedLessons()
        {
            return await _userLearnedLessonsRepository.getAllUserLearnedLessons();
        }

        public async Task CreateNewUserLearnedLesson(UserLearnedLessons userLearnedLesson)
        {
            await _userLearnedLessonsRepository.createNewUserLearnedLesson(userLearnedLesson);
        }

        public async Task<UserLearnedLessons> FindUserLearnedLessonByUserIdLessonId(int userId, int lessonId)
        {
            return await _userLearnedLessonsRepository.findUserLearnedLessonByUserIdLessonId(userId, lessonId);
        }
    }
}
