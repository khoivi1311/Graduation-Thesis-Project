using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface ICourseVotesServices
    {
        Task<IEnumerable<CourseVotes>> GetAllCourseVotes();
    }
}
