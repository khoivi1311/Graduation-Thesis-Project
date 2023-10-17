namespace learn_programming_services.Database.Repository
{
    public class ContestTasksRepository : IContestTasksRepository
    {
        private readonly LearnProgrammingContext _context;

        public ContestTasksRepository(LearnProgrammingContext context)
        {
            _context = context;
        }
    }
}
