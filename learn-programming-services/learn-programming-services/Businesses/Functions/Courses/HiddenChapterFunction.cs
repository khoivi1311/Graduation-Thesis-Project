using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IHiddenChapterFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class HiddenChapterFunction : IHiddenChapterFunction
    {
        private readonly IChaptersServices _chaptersServices;

        public HiddenChapterFunction(IChaptersServices chaptersServices)
        {
            _chaptersServices = chaptersServices;
        }

        public async Task<Response> HiddenChapter(Request request)
        {
            var response = await _chaptersServices.HiddenChapter(request);
            return response;
        }
    }
}
