using learn_programming_services.Businesses.Functions.Practices;
using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class PracticeTestCasesServices : IPracticeTestCasesServices
    {
        private readonly IPracticeTestCasesRepository _practiceTestCasesRepository;

        public PracticeTestCasesServices(IPracticeTestCasesRepository practiceTestCasesRepository)
        {
            _practiceTestCasesRepository = practiceTestCasesRepository;
        }

        public async Task CreateNewPracticeTestCase(PracticeTestCases practiceTestCase)
        {
            await _practiceTestCasesRepository.createNewPracticeTestCase(practiceTestCase);
        }

        public async Task<IEnumerable<PracticeTestCases>> FindPracticeTestCasesByPracticeId(int practiceId)
        {
            return await _practiceTestCasesRepository.findPracticeTestCasesByPracticeId(practiceId);
        }

        public async Task<IDeletePracticeTestCaseFunction.Response> DeletePracticeTestCase(IDeletePracticeTestCaseFunction.Request request)
        {
            var testCase = await _practiceTestCasesRepository.findPracticeTestCaseById(request.id);

            if(testCase != null && testCase.IsDeleted.Equals(false))
            {
                testCase.IsDeleted = true;
                testCase.UpdateDate = DateTime.UtcNow;

                await _practiceTestCasesRepository.updatePracticeTestCase(testCase);

                return new IDeletePracticeTestCaseFunction.Response(true, null);
            }

            return new IDeletePracticeTestCaseFunction.Response(false, "The practice test case is not exist");
        }

        public async Task UpdatePracticeTestCase(PracticeTestCases practiceTestCase)
        {
            await _practiceTestCasesRepository.updatePracticeTestCase(practiceTestCase);
        }
    }
}
