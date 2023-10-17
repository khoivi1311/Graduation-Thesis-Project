using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface IUserStudyCoursesServices
    {
        Task<IEnumerable<UserStudyCourses>> GetAllUserStudyCourses();

        Task CreateNewUserStudyCourse(UserStudyCourses userStudyCourse);

        Task<UserStudyCourses> FindUserStudyCourseByCourseIdAndUserId(int courseId, int userId);

        Task UpdateUserStudyCourse(UserStudyCourses userStudyCourse);
    }
}
