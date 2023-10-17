using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.ICreateNewChapterFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class CreateNewChapterFunction : ICreateNewChapterFunction
    {
        private readonly IChaptersServices _chaptersServices;

        public CreateNewChapterFunction(IChaptersServices chaptersServices)
        {
            _chaptersServices = chaptersServices;
        }

        public async Task<Response> CreateNewChapter(Request request)
        {
            if((request.newChapter.chapterName != null && request.newChapter.chapterName.Trim() != "") && request.newChapter.courseId > 0)
            {
                var response = await _chaptersServices.CreateNewChapter(request);
                return response;
            }
            return new Response(false, "The fields are not allowed to be null");
        }
    }
}
