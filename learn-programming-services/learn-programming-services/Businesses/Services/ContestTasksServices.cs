using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class ContestTasksServices : IContestTasksServices
    {
        private readonly IContestTasksRepository _contestTasksRepository;

        public ContestTasksServices(IContestTasksRepository contestTasksRepository)
        {
            _contestTasksRepository = contestTasksRepository;
        }
    }
}
