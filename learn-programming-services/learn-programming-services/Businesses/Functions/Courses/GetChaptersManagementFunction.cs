using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IGetChaptersManagementFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class GetChaptersManagementFunction : IGetChaptersManagementFunction
    {
        private readonly IChaptersServices _chaptersServices;

        public GetChaptersManagementFunction(IChaptersServices chaptersServices)
        {
            _chaptersServices = chaptersServices;
        }

        public async Task<Response> GetChaptersManagement(Request request)
        {
            if(request.courseId > 0)
            {
                var response = await _chaptersServices.GetChaptersManagement(request);
                return response;
            }
            return new Response();
        }
    }
}
