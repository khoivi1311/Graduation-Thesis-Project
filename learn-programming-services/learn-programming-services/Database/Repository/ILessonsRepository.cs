using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface ILessonsRepository
    {
        Task<IEnumerable<Lessons>> getAllLessons();

        Task createNewLesson(Lessons lesson);

        Task<Lessons> findLatestLesson();

        Task<Lessons> findLessonById(int id);

        Task updateLesson(Lessons lesson);
    }
}
