using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface IUserLearnedLessonsServices
    {
        Task<IEnumerable<UserLearnedLessons>> GetAllUserLearnedLessons();

        Task CreateNewUserLearnedLesson(UserLearnedLessons userLearnedLesson);

        Task<UserLearnedLessons> FindUserLearnedLessonByUserIdLessonId(int userId, int lessonId);
    }
}
