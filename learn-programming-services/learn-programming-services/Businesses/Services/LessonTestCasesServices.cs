using learn_programming_services.Businesses.Functions.Courses;
using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class LessonTestCasesServices : ILessonTestCasesServices
    {
        private readonly ILessonTestCasesRepository _lessonTestCasesRepository;

        public LessonTestCasesServices(ILessonTestCasesRepository lessonTestCasesRepository)
        {
            _lessonTestCasesRepository = lessonTestCasesRepository;
        }

        public async Task CreateNewLessonTestCases(LessonTestCases lessonTestCase)
        {
            await _lessonTestCasesRepository.createNewLessonTestCase(lessonTestCase);
        }

        public async Task<IEnumerable<LessonTestCases>> FindLessonTestCasesByLessonId(int lessonId)
        {
            return await _lessonTestCasesRepository.findLessonTestCasesByLessonId(lessonId);
        }

        public async Task UpdateLessonTestCase(LessonTestCases lessonTestCase)
        {
            await _lessonTestCasesRepository.updateLessonTestCase(lessonTestCase);
        }

        public async Task<IDeleteLessonTestCaseFunction.Response> DeleteLessonTestCase(IDeleteLessonTestCaseFunction.Request request)
        {
            var testCase = await _lessonTestCasesRepository.findLessonTestCaseById(request.id);

            if (testCase != null && testCase.IsDeleted.Equals(false))
            {
                testCase.IsDeleted = true;
                testCase.UpdateDate = DateTime.UtcNow;

                await _lessonTestCasesRepository.updateLessonTestCase(testCase);

                return new IDeleteLessonTestCaseFunction.Response(true, null);
            }

            return new IDeleteLessonTestCaseFunction.Response(false, "The lesson test case is not exist");
        }
    }
}
