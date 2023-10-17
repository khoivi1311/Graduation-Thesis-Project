namespace learn_programming_services.Database.Repository
{
    public class ContestTaskHistoriesRepository : IContestTaskHistoriesRepository
    {
        private readonly LearnProgrammingContext _context;

        public ContestTaskHistoriesRepository(LearnProgrammingContext context)
        {
            _context = context;
        }
    }
}
