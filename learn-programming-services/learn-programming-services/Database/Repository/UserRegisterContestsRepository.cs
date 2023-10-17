namespace learn_programming_services.Database.Repository
{
    public class UserRegisterContestsRepository : IUserRegisterContestsRepository
    {
        private readonly LearnProgrammingContext _context;

        public UserRegisterContestsRepository(LearnProgrammingContext context)
        {
            _context = context;
        }
    }
}
