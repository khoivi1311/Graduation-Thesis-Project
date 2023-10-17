using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface ICoursesRepository
    {
        Task<IEnumerable<Courses>> getAllCourses();

        Task<Courses> findCourseById(int id);

        Task createNewCourse(Courses newCourse);

        Task<Courses> findLatestCourse();

        Task updateCourse(Courses course);
    }
}
