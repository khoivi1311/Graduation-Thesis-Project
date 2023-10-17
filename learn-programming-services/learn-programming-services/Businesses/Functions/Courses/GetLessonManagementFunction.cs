using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IGetLessonManagementFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class GetLessonManagementFunction : IGetLessonManagementFunction
    {
        private readonly ILessonsServices _lessonsServices;

        public GetLessonManagementFunction(ILessonsServices lessonsServices)
        {
            _lessonsServices = lessonsServices;
        }

        public async Task<Response> GetLessonManagement(Request request)
        {
            if (request.chapterId > 0)
            {
                var response = await _lessonsServices.GetLessonManagement(request);
                return response;
            }

            return new Response();
        }
    }
}
