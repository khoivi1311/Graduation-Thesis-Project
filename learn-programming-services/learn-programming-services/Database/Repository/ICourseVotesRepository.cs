using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface ICourseVotesRepository
    {
        Task<IEnumerable<CourseVotes>> getAllCourseVotes();
    }
}
