using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Repository
{
    public class ThemesRepository : IThemesRepository
    {
        private readonly LearnProgrammingContext _context;

        public ThemesRepository(LearnProgrammingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Themes>> getAllThemes()
        {
            return await _context.Themes.AsNoTracking().ToListAsync();
        }
    }
}
