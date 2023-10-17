using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class LessonReplyCommentsRepository : ILessonReplyCommentsRepository
    {
        private readonly LearnProgrammingContext _context;
        
        public LessonReplyCommentsRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task createNewLessonReplyComment(LessonReplyComments lessonReplyComment)
        {
            _context.LessonReplyComments.Add(lessonReplyComment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LessonReplyComments>> getAllLessonReplyComments()
        {
            return await _context.LessonReplyComments.AsNoTracking().ToListAsync();
        }

        public async Task<LessonReplyComments> findLessonReplyCommentById(int id)
        {
            return await _context.LessonReplyComments.FindAsync(id);
        }

        public async Task updateLessonReplyComment(LessonReplyComments lessonReplyComment)
        {
            _context.LessonReplyComments.Update(lessonReplyComment);
            await _context.SaveChangesAsync();
        }
    }
}
