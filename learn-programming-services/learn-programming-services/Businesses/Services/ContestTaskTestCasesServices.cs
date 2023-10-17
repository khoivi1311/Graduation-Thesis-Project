using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class ContestTaskTestCasesServices : IContestTaskTestCasesServices
    {
        private readonly IContestTaskTestCasesRepository _contestTaskTestCasesRepository;

        public ContestTaskTestCasesServices(IContestTaskTestCasesRepository contestTaskTestCasesRepository)
        {
            _contestTaskTestCasesRepository = contestTaskTestCasesRepository;
        }
    }
}
