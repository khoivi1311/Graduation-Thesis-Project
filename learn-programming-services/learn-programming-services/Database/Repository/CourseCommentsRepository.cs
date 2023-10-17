using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class CourseCommentsRepository : ICourseCommentsRepository
    {
        private readonly LearnProgrammingContext _context;

        public CourseCommentsRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task createNewCourseComment(CourseComments courseComment)
        {
            _context.CourseComments.Add(courseComment);
            await _context.SaveChangesAsync();
        }

        public async Task<CourseComments> findCourseCommentById(int id)
        {
            return await _context.CourseComments.FindAsync(id);
        }

        public async Task<IEnumerable<CourseComments>> getAllCourseComments()
        {
            return await _context.CourseComments.AsNoTracking().ToListAsync();
        }

        public async Task updateCourseComment(CourseComments courseComment)
        {
            _context.CourseComments.Update(courseComment);
            await _context.SaveChangesAsync();
        }
    }
}
