using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class ContestTaskCodeLanguagesServices : IContestTaskCodeLanguagesServices
    {
        private readonly IContestTaskCodeLanguagesRepository _contestTaskCodeLanguagesRepository;

        public ContestTaskCodeLanguagesServices(IContestTaskCodeLanguagesRepository contestTaskCodeLanguagesRepository)
        {
            _contestTaskCodeLanguagesRepository = contestTaskCodeLanguagesRepository;
        }
    }
}
