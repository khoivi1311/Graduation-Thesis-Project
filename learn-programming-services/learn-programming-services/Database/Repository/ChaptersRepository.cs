using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class ChaptersRepository : IChaptersRepository
    {
        private readonly LearnProgrammingContext _context;

        public ChaptersRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Chapters>> getAllChapters()
        {
            return await _context.Chapters.AsNoTracking().ToListAsync();
        }

        public async Task createNewChapter(Chapters chapter)
        {
            _context.Chapters.Add(chapter);
            await _context.SaveChangesAsync();
        }

        public async Task<Chapters> findChapterById(int id)
        {
            return await _context.Chapters.FindAsync(id);
        }

        public async Task updateChapter(Chapters chapter)
        {
            _context.Chapters.Update(chapter);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Chapters>> findChapterByCourseId(int courseId)
        {
            return await _context.Chapters.Where(c => c.CourseId.Equals(courseId)).AsNoTracking().ToListAsync();
        }
    }
}
