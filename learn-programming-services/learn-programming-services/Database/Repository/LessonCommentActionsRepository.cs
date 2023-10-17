using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class LessonCommentActionsRepository : ILessonCommentActionsRepository
    {
        private readonly LearnProgrammingContext _context;

        public LessonCommentActionsRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task createNewLessonCommentAction(LessonCommentActions lessonCommentAction)
        {
            _context.LessonCommentActions.Add(lessonCommentAction);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LessonCommentActions>> getAllLessonCommentActions()
        {
            return await _context.LessonCommentActions.AsNoTracking().ToListAsync();
        }

        public async Task updateLessonCommentAction(LessonCommentActions lessonCommentAction)
        {
            _context.LessonCommentActions.Update(lessonCommentAction);
            await _context.SaveChangesAsync();
        }
    }
}
