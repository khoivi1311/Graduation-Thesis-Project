using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class LessonCommentsRepository : ILessonCommentsRepository
    {
        private readonly LearnProgrammingContext _context;
        public LessonCommentsRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task createNewLessonComment(LessonComments lessonComment)
        {
            _context.LessonComments.Add(lessonComment);
            await _context.SaveChangesAsync();
        }

        public async Task<LessonComments> findLessonCommentById(int id)
        {
            return await _context.LessonComments.FindAsync(id);
        }

        public async Task<IEnumerable<LessonComments>> getAllLessonComments()
        {
            return await _context.LessonComments.AsNoTracking().ToListAsync();
        }

        public async Task updateLessonComment(LessonComments lessonComment)
        {
            _context.LessonComments.Update(lessonComment);
            await _context.SaveChangesAsync();
        }
    }
}
