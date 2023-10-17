using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class LessonCodeSamplesRepository : ILessonCodeSamplesRepository
    {
        private readonly LearnProgrammingContext _context;

        public LessonCodeSamplesRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task createNewLessonCodeSample(LessonCodeSamples lessonCodeSample)
        {
            _context.LessonCodeSamples.Add(lessonCodeSample);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LessonCodeSamples>> findLessonCodeSamplesByLessonId(int lessonId)
        {
            return await _context.LessonCodeSamples.Where(l => l.LessonId.Equals(lessonId)).AsNoTracking().ToListAsync();
        }

        public async Task updateLessonCodeSample(LessonCodeSamples lessonCodeSample)
        {
            _context.LessonCodeSamples.Update(lessonCodeSample);
            await _context.SaveChangesAsync();
        }
    }
}
