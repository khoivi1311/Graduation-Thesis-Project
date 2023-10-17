using learn_programming_services.Businesses.Functions.Courses;
using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;
using learn_programming_services.Utils;

namespace learn_programming_services.Businesses.Services
{
    public class LessonHistoriesServices : ILessonHistoriesServices
    {
        private readonly ILessonHistoriesRepository _lessonHistoriesRepository;
        private readonly IUsersServices _usersServices;
        private readonly ICodeLanguagesServices _codeLanguagesServices;
        private readonly ICommonUtil _commonUtil;

        public LessonHistoriesServices(ILessonHistoriesRepository lessonHistoriesRepository, 
            IUsersServices usersServices, 
            ICodeLanguagesServices codeLanguagesServices, 
            ICommonUtil commonUtil)
        {
            _lessonHistoriesRepository = lessonHistoriesRepository;
            _usersServices = usersServices;
            _codeLanguagesServices = codeLanguagesServices;
            _commonUtil = commonUtil;
        }

        public async Task<IEnumerable<LessonHistories>> FindLessonHistoryByUserIdAndLessonId(int userId, int lessonId)
        {
            return await _lessonHistoriesRepository.findLessonHistoryByUserIdAndLessonId(userId, lessonId);
        }

        public async Task CreateNewLessonHistory(LessonHistories lessonHistory)
        {
            await _lessonHistoriesRepository.createNewLessonHistory(lessonHistory);
        }

        public async Task<IGetLessonHistoriesFunction.Response> GetLessonHistories(IGetLessonHistoriesFunction.Request request)
        {
            var lessonHistories = await _lessonHistoriesRepository.findLessonHistoryByUserIdAndLessonId(request.userId, request.lessonId);

            List<IGetLessonHistoriesFunction.LessonHistory> lessonHistoriesList = new List<IGetLessonHistoriesFunction.LessonHistory>();

            if (lessonHistories != null && lessonHistories.Count() > 0) 
            {
                var user = await _usersServices.FindUserById(request.userId);
                var codeLanguages = await _codeLanguagesServices.GetAllCodeLanguages();

                foreach (var lessonHistory in lessonHistories)
                {
                    IGetLessonHistoriesFunction.LessonHistory data = new IGetLessonHistoriesFunction.LessonHistory() 
                    {
                        historyId = lessonHistory.Id,
                        submittedDate = lessonHistory.SubmittedDate.ToLocalTime(),
                        codeLanguageId = lessonHistory.CodeLanguageId,
                        codeLanguageName = codeLanguages.FirstOrDefault(c => c.Id.Equals(lessonHistory.CodeLanguageId)).Name,
                        codeLanguageVersion = codeLanguages.FirstOrDefault(c => c.Id.Equals(lessonHistory.CodeLanguageId)).Version,
                        codeSubmitted = lessonHistory.CodeSubmitted,
                        testCase = lessonHistory.TestCase,
                        score = lessonHistory.Score,
                        userSubmitted = user.UserName,
                    };

                    lessonHistoriesList.Add(data);
                }
            }

            return new IGetLessonHistoriesFunction.Response(lessonHistoriesList);
        }

        public async Task<IGetLessonLeaderboardFunction.Response> GetLessonLeaderboard(IGetLessonLeaderboardFunction.Request request)
        {
            var histories = await _lessonHistoriesRepository.findLessonHistoryByLessonId(request.lessonId);

            if (histories != null && histories.Count() > 0) 
            {
                var codeLanguages = await _codeLanguagesServices.GetAllCodeLanguages();
                var users = await _usersServices.GetAllUsers();

                int totalPages = await _commonUtil.totalPages(request.pageSize, histories.Count());

                histories = histories
                    .Skip((request.pageNumber - 1) * request.pageSize)
                    .Take(request.pageSize).ToList();

                List<IGetLessonLeaderboardFunction.Leaderboard> leaderboardsList = new List<IGetLessonLeaderboardFunction.Leaderboard>();

                foreach(var history in histories)
                {
                    IGetLessonLeaderboardFunction.Leaderboard data = new IGetLessonLeaderboardFunction.Leaderboard()
                    {
                        authorName = users.SingleOrDefault(u => u.Id.Equals(history.AuthorId)).UserName,
                        codeLanguageName = codeLanguages.SingleOrDefault(c => c.Id.Equals(history.CodeLanguageId)).Name,
                        codeLanguageVersion = codeLanguages.SingleOrDefault(c => c.Id.Equals(history.CodeLanguageId)).Version,
                        score = history.Score,
                        submittedDate = history.SubmittedDate.ToLocalTime(),
                    };

                    leaderboardsList.Add(data);
                }

                return new IGetLessonLeaderboardFunction.Response(totalPages, leaderboardsList);
            }

            return new IGetLessonLeaderboardFunction.Response(0, null);
        }
    }
}
