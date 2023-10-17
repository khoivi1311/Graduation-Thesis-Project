using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly LearnProgrammingContext _context;

        public CoursesRepository(LearnProgrammingContext context ) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Courses>> getAllCourses()
        {
            return await _context.Courses.AsNoTracking().ToListAsync();
        }

        public async Task<Courses> findCourseById(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task createNewCourse(Courses newCourse)
        {
            _context.Courses.Add(newCourse);
            await _context.SaveChangesAsync();
        }

        public async Task<Courses> findLatestCourse()
        {
            return await _context.Courses.OrderByDescending(u => u.Id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task updateCourse(Courses course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }
    }
}
