using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class ContestTaskHistoriesServices : IContestTaskHistoriesServices
    {
        private readonly IContestTaskHistoriesRepository _contestTaskHistoriesRepository;

        public ContestTaskHistoriesServices(IContestTaskHistoriesRepository contestTaskHistoriesRepository)
        {
            _contestTaskHistoriesRepository = contestTaskHistoriesRepository;
        }
    }
}
