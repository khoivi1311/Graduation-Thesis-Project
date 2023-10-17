using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class CourseReplyCommentActionsRepository : ICourseReplyCommentActionsRepository
    {
        private readonly LearnProgrammingContext _context;

        public CourseReplyCommentActionsRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task createNewCourseReplyCommentAction(CourseReplyCommentActions courseReplyCommentAction)
        {
            _context.CourseReplyCommentActions.Add(courseReplyCommentAction);
            await _context.SaveChangesAsync();
        }

        public async Task updateCourseReplyCommentAction(CourseReplyCommentActions courseReplyCommentAction)
        {
            _context.CourseReplyCommentActions.Update(courseReplyCommentAction);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CourseReplyCommentActions>> getAllCourseReplyCommentActions()
        {
            return await _context.CourseReplyCommentActions.AsNoTracking().ToListAsync();
        }
    }
}
