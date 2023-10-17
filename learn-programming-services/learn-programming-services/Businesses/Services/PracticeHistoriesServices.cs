using learn_programming_services.Businesses.Functions.Practices;
using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;
using learn_programming_services.Utils;

namespace learn_programming_services.Businesses.Services
{
    public class PracticeHistoriesServices : IPracticeHistoriesServices
    {
        private readonly IPracticeHistoriesRepository _practiceHistoriesRepository;
        private readonly IUsersServices _usersServices;
        private readonly ICodeLanguagesServices _codeLanguagesServices;
        private readonly ICommonUtil _commonUtil;

        public PracticeHistoriesServices(IPracticeHistoriesRepository practiceHistoriesRepository,
            IUsersServices usersServices,
            ICodeLanguagesServices codeLanguagesServices,
            ICommonUtil commonUtil)
        {
            _practiceHistoriesRepository = practiceHistoriesRepository;
            _usersServices = usersServices;
            _codeLanguagesServices = codeLanguagesServices;
            _commonUtil = commonUtil;
        }

        public async Task<IEnumerable<PracticeHistories>> GetAllPracticeHistories()
        {
            return await _practiceHistoriesRepository.getAllPracticeHistories();
        }

        public async Task<IEnumerable<PracticeHistories>> FindPracticeHistoriesByPracticeId(int practiceId) 
        {
            return await _practiceHistoriesRepository.findPracticeHistoriesByPracticeId(practiceId);
        }

        public async Task<IEnumerable<PracticeHistories>> FindPracticeHistoriesByUserIdAndPracticeId(int userId, int practiceId)
        {
            return await _practiceHistoriesRepository.findPracticeHistoriesByUserIdAndPracticeId(userId, practiceId);
        }

        public async Task CreateNewPracticeHistory(PracticeHistories practiceHistory)
        {
            await _practiceHistoriesRepository.createNewPracticeHistory(practiceHistory);
        }

        public async Task<IGetPracticeHistoriesFunction.Response> GetPracticeHistories(IGetPracticeHistoriesFunction.Request request)
        {
            var histories = await _practiceHistoriesRepository.findPracticeHistoriesByUserIdAndPracticeId(request.userId, request.practiceId);

            List<IGetPracticeHistoriesFunction.PracticeHistory> historiesList = new List<IGetPracticeHistoriesFunction.PracticeHistory>();

            if(histories != null && histories.Count() > 0)
            {
                var user = await _usersServices.FindUserById(request.userId);
                var codeLanguages = await _codeLanguagesServices.GetAllCodeLanguages();

                foreach (var history in histories)
                {
                    IGetPracticeHistoriesFunction.PracticeHistory data = new IGetPracticeHistoriesFunction.PracticeHistory()
                    {
                        historyId = history.Id,
                        submittedDate = history.SubmittedDate.ToLocalTime(),
                        codeLanguageId = history.CodeLanguageId,
                        codeLanguageName = codeLanguages.FirstOrDefault(c => c.Id.Equals(history.CodeLanguageId)).Name,
                        codeLanguageVersion = codeLanguages.FirstOrDefault(c => c.Id.Equals(history.CodeLanguageId)).Version,
                        codeSubmitted = history.CodeSubmitted,
                        testCase = history.TestCase,
                        score = history.Score,
                        userSubmitted = user.UserName,
                    };

                    historiesList.Add(data);
                }
            }

            return new IGetPracticeHistoriesFunction.Response(historiesList);
        }

        public async Task<IGetPracticeLeaderboardFunction.Response> GetPracticeLeaderboard(IGetPracticeLeaderboardFunction.Request request)
        {
            var histories = await _practiceHistoriesRepository.findPracticeHistoriesByPracticeId(request.practiceId);

            if (histories != null && histories.Count() > 0)
            {
                var codeLanguages = await _codeLanguagesServices.GetAllCodeLanguages();
                var users = await _usersServices.GetAllUsers();

                int totalPages = await _commonUtil.totalPages(request.pageSize, histories.Count());

                histories = histories
                    .Skip((request.pageNumber - 1) * request.pageSize)
                    .Take(request.pageSize).ToList();

                List<IGetPracticeLeaderboardFunction.Leaderboard> leaderboardsList = new List<IGetPracticeLeaderboardFunction.Leaderboard>();

                foreach (var history in histories)
                {
                    IGetPracticeLeaderboardFunction.Leaderboard data = new IGetPracticeLeaderboardFunction.Leaderboard()
                    {
                        authorName = users.SingleOrDefault(u => u.Id.Equals(history.AuthorId)).UserName,
                        codeLanguageName = codeLanguages.SingleOrDefault(c => c.Id.Equals(history.CodeLanguageId)).Name,
                        codeLanguageVersion = codeLanguages.SingleOrDefault(c => c.Id.Equals(history.CodeLanguageId)).Version,
                        score = history.Score,
                        submittedDate = history.SubmittedDate.ToLocalTime(),
                    };

                    leaderboardsList.Add(data);
                }

                return new IGetPracticeLeaderboardFunction.Response(totalPages, leaderboardsList);
            }

            return new IGetPracticeLeaderboardFunction.Response(0, null);
        }
    }
}
