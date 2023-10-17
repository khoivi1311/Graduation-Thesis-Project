using learn_programming_services.Businesses.Functions.Practices;
using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface IPracticeTestCasesServices
    {
        Task CreateNewPracticeTestCase(PracticeTestCases practiceTestCase);

        Task<IEnumerable<PracticeTestCases>> FindPracticeTestCasesByPracticeId(int practiceId);

        Task<IDeletePracticeTestCaseFunction.Response> DeletePracticeTestCase(IDeletePracticeTestCaseFunction.Request request);

        Task UpdatePracticeTestCase(PracticeTestCases practiceTestCase);
    }
}
