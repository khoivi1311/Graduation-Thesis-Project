using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface IUserStudyCoursesRepository
    {
        Task<IEnumerable<UserStudyCourses>> getAllUserStudyCourses();

        Task createNewUserStudyCourse(UserStudyCourses userStudyCourse);

        Task<UserStudyCourses> findUserStudyCourseByCourseIdAndUserId(int courseId, int userId);

        Task updateUserStudyCourse(UserStudyCourses userStudyCourse);
    }
}
