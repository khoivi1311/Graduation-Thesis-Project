using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface IPracticeTestCasesRepository
    {
        Task createNewPracticeTestCase(PracticeTestCases practiceTestCase);

        Task<IEnumerable<PracticeTestCases>> findPracticeTestCasesByPracticeId(int practiceId);

        Task<PracticeTestCases> findPracticeTestCaseById(int id);

        Task updatePracticeTestCase(PracticeTestCases practiceTestCase);
    }
}
