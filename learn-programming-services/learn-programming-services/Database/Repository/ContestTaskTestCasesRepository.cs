namespace learn_programming_services.Database.Repository
{
    public class ContestTaskTestCasesRepository : IContestTaskTestCasesRepository
    {
        private readonly LearnProgrammingContext _context;

        public ContestTaskTestCasesRepository(LearnProgrammingContext context)
        {
            _context = context;
        }
    }
}
