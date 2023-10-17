using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface IUserLearnedLessonsRepository
    {
        Task<IEnumerable<UserLearnedLessons>> getAllUserLearnedLessons();

        Task createNewUserLearnedLesson(UserLearnedLessons userLearnedLesson);

        Task<UserLearnedLessons> findUserLearnedLessonByUserIdLessonId(int userId, int lessonId);
    }
}
