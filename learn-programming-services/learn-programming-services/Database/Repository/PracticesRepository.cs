using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class PracticesRepository : IPracticesRepository
    {
        private readonly LearnProgrammingContext _context;

        public PracticesRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task createNewPractice(Practices practice)
        {
            _context.Practices.Add(practice);
            await _context.SaveChangesAsync();
        }

        public async Task<Practices> findLatestPractice()
        {
            return await _context.Practices.OrderByDescending(u => u.Id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Practices>> getAllPractices()
        {
            return await _context.Practices.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Practices>> findPracticeByUserId(int userId)
        {
            return await _context.Practices.Where(p => p.AuthorId.Equals(userId)).AsNoTracking().ToListAsync();
        }

        public async Task<Practices> findPracticeById(int id)
        {
            return await _context.Practices.FindAsync(id);
        }

        public async Task updatePractice(Practices practice)
        {
            _context.Practices.Update(practice);
            await _context.SaveChangesAsync();
        }
    }
}
