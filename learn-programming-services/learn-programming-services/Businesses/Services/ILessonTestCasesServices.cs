using learn_programming_services.Businesses.Functions.Courses;
using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface ILessonTestCasesServices
    {
        Task CreateNewLessonTestCases(LessonTestCases lessonTestCase);

        Task<IEnumerable<LessonTestCases>> FindLessonTestCasesByLessonId(int lessonId);

        Task UpdateLessonTestCase(LessonTestCases lessonTestCase);

        Task<IDeleteLessonTestCaseFunction.Response> DeleteLessonTestCase(IDeleteLessonTestCaseFunction.Request request);
    }
}
