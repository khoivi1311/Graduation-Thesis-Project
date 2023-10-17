using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class UserTokensRepository : IUserTokensRepository
    {
        private readonly LearnProgrammingContext _context;

        public UserTokensRepository(LearnProgrammingContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<UserTokens>> getAllUserTokens()
        {
            return await _context.UserTokens.AsNoTracking().ToListAsync();
        }

        public async Task createNewUserToken(UserTokens userTokens)
        {
            _context.Add(userTokens);
            await _context.SaveChangesAsync();
        }

        public async Task updateUserToken(UserTokens userTokens)
        {
            _context.Update(userTokens);
            await _context.SaveChangesAsync();
        }
    }
}
