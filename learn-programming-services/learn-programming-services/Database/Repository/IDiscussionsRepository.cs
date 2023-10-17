using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface IDiscussionsRepository
    {
        Task createNewDiscussion(Discussions discussions);

        Task<Discussions> findDiscussionById(int id);

        Task updateDiscussion(Discussions discussions);

        Task<IEnumerable<Discussions>> getAllDiscussions();
    }
}
