using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly LearnProgrammingContext _context;

        public UsersRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Users>> getAllUsers()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task createNewUser(Users user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<Users> findLatestUser()
        {
            return await _context.Users.OrderByDescending(u => u.Id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Users> findUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task updateUser(Users user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
