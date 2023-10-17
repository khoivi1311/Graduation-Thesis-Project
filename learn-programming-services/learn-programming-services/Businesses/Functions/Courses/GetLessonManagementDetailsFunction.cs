using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IGetLessonManagementDetailsFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class GetLessonManagementDetailsFunction : IGetLessonManagementDetailsFunction
    {
        private readonly ILessonsServices _lessonsServices;

        public GetLessonManagementDetailsFunction(ILessonsServices lessonsServices)
        {
            _lessonsServices = lessonsServices;
        }

        public async Task<Response> GetLessonManagementDetails(Request request)
        {
            if (request.id > 0) 
            {
                var response = await _lessonsServices.GetLessonManagementDetails(request);
                return response;
            }
            return new Response();
        }
    }
}
