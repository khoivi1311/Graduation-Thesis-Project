using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class CodeLanguagesRepository : ICodeLanguagesRepository
    {
        private readonly LearnProgrammingContext _context;

        public CodeLanguagesRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CodeLanguages>> getAllCodeLanguages()
        {
            return await _context.CodeLanguages.AsNoTracking().ToListAsync();
        }

        public async Task<CodeLanguages> findCodeLanguageById(int id)
        {
            return await _context.CodeLanguages.FindAsync(id);
        }
    }
}
