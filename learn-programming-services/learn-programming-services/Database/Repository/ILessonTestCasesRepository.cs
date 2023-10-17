using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface ILessonTestCasesRepository
    {
        Task createNewLessonTestCase(LessonTestCases lessonTestCase);

        Task<IEnumerable<LessonTestCases>> findLessonTestCasesByLessonId(int lessonId);

        Task updateLessonTestCase(LessonTestCases lessonTestCase);

        Task<LessonTestCases> findLessonTestCaseById(int id);
    }
}
