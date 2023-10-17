using learn_programming_services.Businesses.Functions.Courses;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class ThemesServices : IThemesServices
    {
        private readonly IThemesRepository _themesRepository;

        public ThemesServices(IThemesRepository hemesRepository)
        {
            _themesRepository = hemesRepository;
        }

        public async Task<IGetThemesFunction.Response> GetThemes()
        {
            var themes = await _themesRepository.getAllThemes();

            List<IGetThemesFunction.Theme> themesList = new List<IGetThemesFunction.Theme>();

            if (themes != null && themes.Count() > 0)
            {
                foreach (var theme in themes)
                {
                    if (theme.IsDeleted.Equals(false) && theme.IsHidden.Equals(false))
                    {
                        IGetThemesFunction.Theme data = new IGetThemesFunction.Theme() 
                        {
                            themeId = theme.Id,
                            themeName = theme.Name,
                            themeImage = theme.Image,
                        };

                        themesList.Add(data);
                    }
                }
            }

            return new IGetThemesFunction.Response(themesList);
        }
    }
}
