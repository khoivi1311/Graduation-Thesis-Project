using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IUpdateChapterFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class UpdateChapterFunction : IUpdateChapterFunction
    {
        private readonly IChaptersServices _chaptersServices;

        public UpdateChapterFunction(IChaptersServices chaptersServices)
        {
            _chaptersServices = chaptersServices;
        }

        public async Task<Response> UpdateChapter(Request request)
        {
            if(request.chapter.chapterId > 0 && (request.chapter.chapterName != null && request.chapter.chapterName.Trim() != ""))
            {
                var response = await _chaptersServices.UpdateChapter(request);
                return response;
            }
            return new Response(false, "The fields are not allowed to be null");
        }
    }
}
