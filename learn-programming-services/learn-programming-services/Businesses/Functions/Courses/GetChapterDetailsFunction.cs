using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IGetChapterDetailsFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class GetChapterDetailsFunction : IGetChapterDetailsFunction
    {
        private readonly IChaptersServices _chaptersServices;

        public GetChapterDetailsFunction(IChaptersServices chaptersServices)
        {
            _chaptersServices = chaptersServices;
        }

        public async Task<Response> GetChapterDetails(Request request)
        {
            if(request.id > 0)
            {
                var response = await _chaptersServices.GetChapterDetails(request);
                return response;
            }

            return new Response();
        }
    }
}
