namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface IGetThemesFunction
    {
        public class Response
        {
            public List<Theme> themes { get; set; }

            public Response(List<Theme> themes)
            {
                this.themes = themes;
            }
        }

        public class Theme
        {
            public int themeId { get; set; }

            public string themeName { get; set; }

            public string themeImage { get; set; }
        }

        Task<Response> GetThemes();
    }
}
