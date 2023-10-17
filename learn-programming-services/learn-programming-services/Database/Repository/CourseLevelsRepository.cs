using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class CourseLevelsRepository : ICourseLevelsRepository
    {
        private readonly LearnProgrammingContext _context;

        public CourseLevelsRepository(LearnProgrammingContext context ) 
        {
            _context = context;
        }

        public async Task<IEnumerable<CourseLevels>> getAllCourseLevels()
        {
            return await _context.CourseLevels.AsNoTracking().ToListAsync();
        }

        public async Task<CourseLevels> findCourseLevelById(int id)
        {
            return await _context.CourseLevels.FindAsync(id);
        }
    }
}
