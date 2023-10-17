namespace learn_programming_services.Database.Repository
{
    public class ContestTaskCodeLanguagesRepository : IContestTaskCodeLanguagesRepository
    {
        private readonly LearnProgrammingContext _context;

        public ContestTaskCodeLanguagesRepository(LearnProgrammingContext context)
        {
            _context = context;
        }
    }
}
