using learn_programming_services.Businesses.Functions.Practices;
using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IDeleteLessonTestCaseFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class DeleteLessonTestCaseFunction : IDeleteLessonTestCaseFunction
    {
        private readonly ILessonTestCasesServices _lessonTestCasesServices;

        public DeleteLessonTestCaseFunction(ILessonTestCasesServices lessonTestCasesServices)
        {
            _lessonTestCasesServices = lessonTestCasesServices;
        }

        public async Task<Response> DeleteLessonTestCase(Request request)
        {
            var response = await _lessonTestCasesServices.DeleteLessonTestCase(request);
            return response;
        }
    }
}
