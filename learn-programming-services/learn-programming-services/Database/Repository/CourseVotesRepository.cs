using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class CourseVotesRepository : ICourseVotesRepository
    {
        private readonly LearnProgrammingContext _context;

        public CourseVotesRepository(LearnProgrammingContext context )
        {
            _context = context;
        }

        public async Task<IEnumerable<CourseVotes>> getAllCourseVotes()
        {
            return await _context.CourseVotes.AsNoTracking().ToListAsync();
        }
    }
}
