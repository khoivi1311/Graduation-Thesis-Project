using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class LessonReplyCommentActionsRepository : ILessonReplyCommentActionsRepository
    {
        private readonly LearnProgrammingContext _context;

        public LessonReplyCommentActionsRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task createNewLessonReplyCommentAction(LessonReplyCommentActions lessonReplyCommentAction)
        {
            _context.LessonReplyCommentActions.Add(lessonReplyCommentAction);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LessonReplyCommentActions>> getAllLessonReplyCommentActions()
        {
            return await _context.LessonReplyCommentActions.AsNoTracking().ToListAsync();
        }

        public async Task updateLessonReplyCommentAction(LessonReplyCommentActions lessonReplyCommentAction)
        {
            _context.LessonReplyCommentActions.Update(lessonReplyCommentAction);
            await _context.SaveChangesAsync();
        }
    }
}
