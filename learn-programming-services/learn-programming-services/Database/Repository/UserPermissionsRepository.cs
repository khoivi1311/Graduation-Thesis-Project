using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class UserPermissionsRepository : IUserPermissionsRepository
    {
        private readonly LearnProgrammingContext _context;

        public UserPermissionsRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task createNewUserPermissions(UserPermissions userPermissions)
        {
            _context.UserPermissions.Add(userPermissions);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserPermissions>> getAllUserPermissions()
        {
            return await _context.UserPermissions.AsNoTracking().ToListAsync();
        }
    }
}
