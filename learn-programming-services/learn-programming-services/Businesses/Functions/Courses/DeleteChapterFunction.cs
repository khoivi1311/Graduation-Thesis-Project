using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IDeleteChapterFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class DeleteChapterFunction : IDeleteChapterFunction
    {
        private readonly IChaptersServices _chaptersServices;

        public DeleteChapterFunction(IChaptersServices chaptersServices)
        {
            _chaptersServices = chaptersServices;
        }

        public async Task<Response> DeleteChapter(Request request)
        {
            var response = await _chaptersServices.DeleteChapter(request);
            return response;
        }
    }
}
