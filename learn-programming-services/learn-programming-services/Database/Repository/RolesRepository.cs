using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public class RolesRepository : IRolesRepository
    {
        private readonly LearnProgrammingContext _context;

        public RolesRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task<Roles> findRoleById(int id)
        {
            return await _context.Roles.FindAsync(id);
        }
    }
}
