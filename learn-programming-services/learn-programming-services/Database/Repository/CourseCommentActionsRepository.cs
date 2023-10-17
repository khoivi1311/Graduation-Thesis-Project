using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class CourseCommentActionsRepository : ICourseCommentActionsRepository
    {
        private readonly LearnProgrammingContext _context;

        public CourseCommentActionsRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task createNewCourseCommentAction(CourseCommentActions courseCommentAction)
        {
            _context.CourseCommentActions.Add(courseCommentAction);
            await _context.SaveChangesAsync();
        }

        public async Task updateCourseCommentAction(CourseCommentActions courseCommentAction)
        {
            _context.CourseCommentActions.Update(courseCommentAction);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CourseCommentActions>> getAllCourseCommentActions()
        {
            return await _context.CourseCommentActions.AsNoTracking().ToListAsync();
        }
    }
}
