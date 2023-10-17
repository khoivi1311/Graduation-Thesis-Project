using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class CourseReplyCommentsRepository : ICourseReplyCommentsRepository
    {
        private readonly LearnProgrammingContext _context;

        public CourseReplyCommentsRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task createNewCourseReplyComment(CourseReplyComments courseReplyComment)
        {
            _context.Add(courseReplyComment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CourseReplyComments>> getAllCourseReplyComments()
        {
            return await _context.CourseReplyComments.AsNoTracking().ToListAsync();
        }

        public async Task<CourseReplyComments> findCourseReplyCommentById(int id)
        {
            return await _context.CourseReplyComments.FindAsync(id);
        }

        public async Task updateCourseReplyComment(CourseReplyComments courseReplyComment)
        {
            _context.Update(courseReplyComment);
            await _context.SaveChangesAsync();
        }
    }
}
