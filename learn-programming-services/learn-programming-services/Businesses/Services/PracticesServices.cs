using learn_programming_services.Businesses.Functions.Practices;
using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;
using learn_programming_services.Utils;

namespace learn_programming_services.Businesses.Services
{
    public class PracticesServices : IPracticesServices
    {
        private readonly IPracticesRepository _practicesRepository;
        private readonly IPracticeTestCasesServices _practiceTestCasesServices;
        private readonly IUsersServices _usersServices;
        private readonly IPracticeLevelsServices _practiceLevelsServices;
        private readonly IPracticeHistoriesServices _practiceHistoriesServices;
        private readonly ICodeLanguagesServices _codeLanguagesServices;
        private readonly ICommonUtil _commonUtil;
        private readonly IJobeServices _jobeServices;

        public PracticesServices(IPracticesRepository practicesRepository,
            IPracticeTestCasesServices practiceTestCasesServices,
            IUsersServices usersServices,
            IPracticeLevelsServices practiceLevelsServices,
            IPracticeHistoriesServices practiceHistoriesServices,
            ICodeLanguagesServices codeLanguagesServices,
            ICommonUtil commonUtil,
            IJobeServices jobeServices)
        {
            _practicesRepository = practicesRepository;
            _practiceTestCasesServices = practiceTestCasesServices;
            _usersServices = usersServices;
            _practiceLevelsServices = practiceLevelsServices;
            _practiceHistoriesServices = practiceHistoriesServices;
            _codeLanguagesServices = codeLanguagesServices;
            _commonUtil = commonUtil;
            _jobeServices = jobeServices;
        }

        public async Task<ICreateNewPracticeFunction.Response> CreateNewPractice(ICreateNewPracticeFunction.Request request)
        {
            Practices newPractice = new Practices()
            {
                Name = request.newPractice.practiceName.Trim(),
                Content = request.newPractice.content.Trim(),
                Score = request.newPractice.score,
                IsDeleted = false,
                IsHidden = true,
                PracticeLevelId = request.newPractice.practiceLevelId,
                AuthorId = request.newPractice.authorId,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow
            };

            await _practicesRepository.createNewPractice(newPractice);

            var latestPractice = await _practicesRepository.findLatestPractice();

            foreach (var testCase in request.newPractice.testCases)
            {
                PracticeTestCases data = new PracticeTestCases()
                {
                    Input = testCase.input.Trim(),
                    ExpectedOutput = testCase.expectedOutput.Trim(),
                    IsHidden = testCase.isHidden,
                    IsDeleted = false,
                    PracticeId = latestPractice.Id,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow
                };

                await _practiceTestCasesServices.CreateNewPracticeTestCase(data);
            }

            return new ICreateNewPracticeFunction.Response(true, null);
        }

        public async Task<IGetPracticesManagementFunction.Response> GetPracticesManagement(IGetPracticesManagementFunction.Request request)
        {
            var practices = await _practicesRepository.findPracticeByUserId(request.userId);

            practices = practices.Where(p => p.IsDeleted.Equals(false)).ToList();

            if (practices != null && practices.Count() > 0)
            {
                if (request.keyword != null && request.keyword.Trim() != "")
                {
                    practices = practices.Where(p => p.Name.ToLower().Contains(request.keyword.ToLower().Trim())).ToList();
                }

                var user = await _usersServices.FindUserById(request.userId);
                var levels = await _practiceLevelsServices.GetAllPracticeLevels();

                int totalPages = await _commonUtil.totalPages(request.pageSize, practices.Count());

                practices = practices.Skip((request.pageNumber - 1) * request.pageSize).Take(request.pageSize).ToList();

                List<IGetPracticesManagementFunction.PracticeManagement> practicesList = new List<IGetPracticesManagementFunction.PracticeManagement>();

                foreach (var practice in practices)
                {
                    IGetPracticesManagementFunction.PracticeManagement data = new IGetPracticesManagementFunction.PracticeManagement()
                    {
                        practiceId = practice.Id,
                        practiceName = practice.Name,
                        score = practice.Score,
                        practiceLevel = levels.FirstOrDefault(l => l.Id.Equals(practice.PracticeLevelId)).Name,
                        authorName = user.UserName,
                        isHidden = practice.IsHidden,
                        createDate = practice.CreateDate.ToLocalTime(),
                        updateDate = practice.UpdateDate.ToLocalTime()
                    };

                    practicesList.Add(data);
                }

                return new IGetPracticesManagementFunction.Response(totalPages, practicesList);
            }

            return new IGetPracticesManagementFunction.Response(0, null);
        }

        public async Task<IGetPracticeDetailsManagementFunction.Response> GetPracticeDetailsManagement(IGetPracticeDetailsManagementFunction.Request request)
        {
            var practiceDetails = await _practicesRepository.findPracticeById(request.id);

            if (practiceDetails != null && practiceDetails.IsDeleted.Equals(false))
            {
                var testCases = await _practiceTestCasesServices.FindPracticeTestCasesByPracticeId(practiceDetails.Id);

                List<IGetPracticeDetailsManagementFunction.TestCase> testCasesList = new List<IGetPracticeDetailsManagementFunction.TestCase>();

                foreach (var testCase in testCases)
                {
                    if (testCase.IsDeleted.Equals(false))
                    {
                        IGetPracticeDetailsManagementFunction.TestCase data = new IGetPracticeDetailsManagementFunction.TestCase()
                        {
                            testCaseId = testCase.Id,
                            input = testCase.Input,
                            expectedOutput = testCase.ExpectedOutput,
                            isHidden = testCase.IsHidden
                        };

                        testCasesList.Add(data);
                    }
                }

                return new IGetPracticeDetailsManagementFunction.Response(practiceDetails.Id, practiceDetails.Name, practiceDetails.Content, practiceDetails.Score, practiceDetails.PracticeLevelId, testCasesList.Where(t => t.isHidden.Equals(false)).Count(), testCasesList.Where(t => t.isHidden.Equals(false)).ToList(), testCasesList.Where(t => t.isHidden.Equals(true)).Count(), testCasesList.Where(t => t.isHidden.Equals(true)).ToList());
            }

            return new IGetPracticeDetailsManagementFunction.Response();
        }

        public async Task<IDeletePracticeFunction.Response> DeletePractice(IDeletePracticeFunction.Request request)
        {
            var practice = await _practicesRepository.findPracticeById(request.id);

            if (practice != null && practice.IsDeleted.Equals(false))
            {
                practice.IsDeleted = true;
                practice.UpdateDate = DateTime.UtcNow;

                await _practicesRepository.updatePractice(practice);

                return new IDeletePracticeFunction.Response(true, null);
            }

            return new IDeletePracticeFunction.Response(false, "The practice is not exist");
        }

        public async Task<IHiddenPracticeFunction.Response> HiddenPractice(IHiddenPracticeFunction.Request request)
        {
            var practice = await _practicesRepository.findPracticeById(request.id);

            if (practice != null && practice.IsDeleted.Equals(false))
            {
                if (practice.IsHidden.Equals(false))
                {
                    practice.IsHidden = true;
                    practice.UpdateDate = DateTime.UtcNow;
                }
                else if (practice.IsHidden.Equals(true))
                {
                    practice.IsHidden = false;
                    practice.UpdateDate = DateTime.UtcNow;
                }

                await _practicesRepository.updatePractice(practice);

                return new IHiddenPracticeFunction.Response(true, null);
            }

            return new IHiddenPracticeFunction.Response(false, "The practice is not exist"); ;
        }

        public async Task<IUpdatePracticeFunction.Response> UpdatePractice(IUpdatePracticeFunction.Request request)
        {
            var practice = await _practicesRepository.findPracticeById(request.practice.practiceId);

            if (practice != null && practice.IsDeleted.Equals(false))
            {
                practice.Name = request.practice.practiceName.Trim();
                practice.Content = request.practice.content.Trim();
                practice.Score = request.practice.score;
                practice.PracticeLevelId = request.practice.practiceLevelId;

                await _practicesRepository.updatePractice(practice);

                var testCases = await _practiceTestCasesServices.FindPracticeTestCasesByPracticeId(practice.Id);

                foreach (var testCase in request.practice.testCases)
                {
                    bool isUpdated = false;

                    foreach (var item in testCases)
                    {
                        if (testCase.testCaseId.Equals(item.Id) && item.IsDeleted.Equals(false))
                        {
                            item.Input = testCase.input.Trim();
                            item.ExpectedOutput = testCase.expectedOutput.Trim();
                            item.IsHidden = testCase.isHidden;
                            item.UpdateDate = DateTime.UtcNow;

                            isUpdated = true;

                            await _practiceTestCasesServices.UpdatePracticeTestCase(item);

                            break;
                        }
                    }

                    if (!isUpdated)
                    {
                        PracticeTestCases practiceTestCase = new PracticeTestCases()
                        {
                            Input = testCase.input.Trim(),
                            ExpectedOutput = testCase.expectedOutput.Trim(),
                            IsHidden = testCase.isHidden,
                            IsDeleted = false,
                            PracticeId = practice.Id,
                            CreateDate = DateTime.UtcNow,
                            UpdateDate = DateTime.UtcNow
                        };

                        await _practiceTestCasesServices.CreateNewPracticeTestCase(practiceTestCase);
                    }
                }

                return new IUpdatePracticeFunction.Response(true, null);
            }

            return new IUpdatePracticeFunction.Response(false, "The practice is not exist");
        }

        public async Task<IGetPracticesFunction.Response> GetPractices(IGetPracticesFunction.Request request)
        {
            var practices = await _practicesRepository.getAllPractices();
            var histories = await _practiceHistoriesServices.GetAllPracticeHistories();
            var users = await _usersServices.GetAllUsers();
            var levels = await _practiceLevelsServices.GetAllPracticeLevels();

            practices = practices
                .Where(p => p.IsHidden.Equals(false))
                .Where(p => p.IsDeleted.Equals(false))
                .ToList();

            if (practices != null && practices.Count() > 0)
            {
                if (request.userId > 0)
                {
                    if (request.keyword != null && request.keyword.Trim() != "")
                    {
                        practices = practices.Where(p => p.Name.ToLower().Contains(request.keyword.Trim().ToLower())).ToList();
                    }

                    if (request.levelId != null && request.levelId >= 1 && request.levelId <= 3)
                    {
                        practices = practices.Where(p => p.PracticeLevelId.Equals(request.levelId)).ToList();
                    }

                    if (request.isCompleted != null)
                    {
                        var history = histories.Where(h => h.AuthorId.Equals(request.userId)).DistinctBy(h => h.PracticeId).ToList();
                        if (request.isCompleted.Equals(true))
                        {
                            List<Practices> practiceData = new List<Practices>();

                            foreach (var item in history)
                            {
                                Practices data = practices.SingleOrDefault(p => p.Id.Equals(item.PracticeId));

                                if (data != null)
                                {
                                    practiceData.Add(data);
                                }

                            }

                            practices = practiceData;
                        }
                        else
                        {
                            foreach (var item in history)
                            {
                                practices = practices.Where(p => !p.Id.Equals(item.PracticeId)).ToList();
                            }
                        }
                    }
                }

                int totalPages = await _commonUtil.totalPages(request.pageSize, practices.Count());

                practices = practices.Skip((request.pageNumber - 1) * request.pageSize).Take(request.pageSize).ToList();

                List<IGetPracticesFunction.Practice> practicesList = new List<IGetPracticesFunction.Practice>();

                foreach (var practice in practices)
                {
                    var history = histories
                        .Where(h => h.PracticeId.Equals(practice.Id))
                        .DistinctBy(h => h.AuthorId).ToList();

                    IGetPracticesFunction.Practice data = new IGetPracticesFunction.Practice()
                    {
                        practiceId = practice.Id,
                        practiceName = practice.Name,
                        level = levels.FirstOrDefault(l => l.Id.Equals(practice.PracticeLevelId)).Name,
                        score = practice.Score,
                        author = users.FirstOrDefault(u => u.Id.Equals(practice.AuthorId)).UserName,
                        numberOfParticipants = history.Count(),
                        isCompleted = false,
                    };

                    if(request.userId > 0)
                    {
                        data.isCompleted = history.Any(h => h.AuthorId.Equals(practice.Id));
                    }

                    practicesList.Add(data);
                }

                return new IGetPracticesFunction.Response(totalPages, practicesList);
            }

            return new IGetPracticesFunction.Response(0, null);
        }

        public async Task<IGetPracticeDetailsFunction.Response> GetPracticeDetails(IGetPracticeDetailsFunction.Request request)
        {
            var practice = await _practicesRepository.findPracticeById(request.practiceId);

            if (practice != null && practice.IsDeleted.Equals(false) && practice.IsHidden.Equals(false))
            {
                var testCases = await _practiceTestCasesServices.FindPracticeTestCasesByPracticeId(practice.Id);
                var histories = await _practiceHistoriesServices.FindPracticeHistoriesByUserIdAndPracticeId(request.userId, practice.Id);
                var levels = await _practiceLevelsServices.GetAllPracticeLevels();
                var user = await _usersServices.FindUserById(practice.AuthorId);

                List<IGetPracticeDetailsFunction.TestCase> testCasesList = new List<IGetPracticeDetailsFunction.TestCase>();

                foreach(var testCase in testCases)
                {
                    if (testCase.IsDeleted.Equals(false))
                    {
                        IGetPracticeDetailsFunction.TestCase data;

                        if (testCase.IsHidden)
                        {
                            data = new IGetPracticeDetailsFunction.TestCase()
                            {
                                testCaseId = testCase.Id,
                                input = null,
                                expectedOutput = null,
                                isHidden = testCase.IsHidden,
                            };
                        }
                        else
                        {
                            data = new IGetPracticeDetailsFunction.TestCase()
                            {
                                testCaseId = testCase.Id,
                                input = testCase.Input,
                                expectedOutput = testCase.ExpectedOutput,
                                isHidden = testCase.IsHidden,
                            };
                        }

                        testCasesList.Add(data);
                    }
                }

                testCasesList = testCasesList.OrderBy(t => t.isHidden).ToList();

                int codeLanguageId = 0;
                string codeSubmitted = null;

                if (histories != null && histories.Count() > 0)
                {
                    var history = histories.OrderByDescending(h => h.SubmittedDate).FirstOrDefault();

                    codeLanguageId = history.CodeLanguageId;
                    codeSubmitted = history.CodeSubmitted;
                }

                var level = levels.SingleOrDefault(l => l.Id.Equals(practice.PracticeLevelId)).Name;

                return new IGetPracticeDetailsFunction.Response(practice.Id, practice.Name, practice.Content, level, practice.Score, user.UserName, codeLanguageId, codeSubmitted, testCasesList);
            }

            return new IGetPracticeDetailsFunction.Response();
        }

        public async Task<IRunCodePracticeFunction.Response> RunCodePractice(IRunCodePracticeFunction.Request request)
        {
            var practice = await _practicesRepository.findPracticeById(request.runCodePractice.practiceId);

            if (practice != null && practice.IsDeleted.Equals(false) && practice.IsHidden.Equals(false))
            {
                var codeLanguage = await _codeLanguagesServices.FindCodeLanguageById(request.runCodePractice.codeLanguageId);
                var testCases = await _practiceTestCasesServices.FindPracticeTestCasesByPracticeId(practice.Id);

                testCases = testCases
                   .Where(t => t.IsHidden.Equals(false))
                   .Where(t => t.IsDeleted.Equals(false))
                   .ToList();

                List<IRunCodePracticeFunction.TestCase> resultList = new List<IRunCodePracticeFunction.TestCase>();

                int pass = 0;

                foreach (var testCase in testCases)
                {
                    IJobeServices.JobeDataInput data = new IJobeServices.JobeDataInput()
                    {
                        language_id = codeLanguage.SubmitName,
                        sourcecode = request.runCodePractice.practiceCode.Trim(),
                        input = testCase.Input
                    };

                    var responseData = await _jobeServices.JobeRun(data);

                    switch (responseData.outcome)
                    {
                        case 11:
                            {
                                return new IRunCodePracticeFunction.Response("0/" + testCases.Count(), "Compilation error", responseData.cmpinfo, null);
                            }
                            break;

                        case 12:
                            {
                                return new IRunCodePracticeFunction.Response("0/" + testCases.Count(), "Runtime error", responseData.stderr, null);
                            }
                            break;

                        case 13:
                            {
                                return new IRunCodePracticeFunction.Response("0/" + testCases.Count(), "Time limit exceeded", responseData.stderr, null);
                            }

                        case 15:
                            {
                                IRunCodePracticeFunction.TestCase testCaseData = new IRunCodePracticeFunction.TestCase()
                                {
                                    testCaseId = testCase.Id,
                                    actualOutput = responseData.stdout.Trim(),
                                    isPassed = testCase.ExpectedOutput.Equals(responseData.stdout.Trim()),
                                };

                                resultList.Add(testCaseData);

                                if (testCase.ExpectedOutput.Equals(responseData.stdout.Trim()))
                                {
                                    pass++;
                                }
                            }
                            break;

                        case 17:
                            {
                                return new IRunCodePracticeFunction.Response("0/" + testCases.Count(), "Memory limit exceeded", responseData.stderr, null);
                            }
                            break;

                        case 19:
                            {
                                return new IRunCodePracticeFunction.Response("0/" + testCases.Count(), "Illegal system call", responseData.stderr, null);
                            }
                            break;

                        case 20:
                            {
                                return new IRunCodePracticeFunction.Response("0/" + testCases.Count(), "Internal error", responseData.stderr, null);
                            }
                            break;

                        case 21:
                            {
                                return new IRunCodePracticeFunction.Response("0/" + testCases.Count(), "Server overload", responseData.stderr, null);
                            }
                            break;
                    }
                }

                return new IRunCodePracticeFunction.Response(pass + "/" + testCases.Count(), null, null, resultList);
            }

            return new IRunCodePracticeFunction.Response(null, "Practice error", "The practice is not exist", null);
        }

        public async Task<ISubmitCodePracticeFunction.Response> SubmitCodePractice(ISubmitCodePracticeFunction.Request request)
        {
            var practice = await _practicesRepository.findPracticeById(request.submitCodePractice.practiceId);

            if (practice != null && practice.IsDeleted.Equals(false) && practice.IsHidden.Equals(false))
            {
                var codeLanguage = await _codeLanguagesServices.FindCodeLanguageById(request.submitCodePractice.codeLanguageId);
                var testCases = await _practiceTestCasesServices.FindPracticeTestCasesByPracticeId(practice.Id);

                testCases = testCases
                        .Where(t => t.IsDeleted.Equals(false))
                        .ToList();

                int samplePass = 0;
                int hiddenPass = 0;

                foreach (var testCase in testCases)
                {
                    IJobeServices.JobeDataInput data = new IJobeServices.JobeDataInput()
                    {
                        language_id = codeLanguage.SubmitName,
                        sourcecode = request.submitCodePractice.practiceCode.Trim(),
                        input = testCase.Input
                    };

                    var responseData = await _jobeServices.JobeRun(data);

                    if (responseData.outcome.Equals(15))
                    {
                        if (testCase.ExpectedOutput.Equals(responseData.stdout.Trim()))
                        {
                            if (testCase.IsHidden.Equals(false))
                            {
                                samplePass++;
                            }
                            else
                            {
                                hiddenPass++;
                            }
                        }
                    }
                }

                int totalPass = samplePass + hiddenPass;

                int score = int.Parse(Math.Round((totalPass) * ((float)practice.Score / testCases.Count())).ToString());

                PracticeHistories practiceHistory = new PracticeHistories()
                {
                    CodeLanguageId = codeLanguage.Id,
                    TestCase = totalPass + "/" + testCases.Count(),
                    Score = score,
                    CodeSubmitted = request.submitCodePractice.practiceCode.Trim(),
                    SubmittedDate = DateTime.UtcNow,
                    PracticeId = practice.Id,
                    AuthorId = request.submitCodePractice.userId
                };

                await _practiceHistoriesServices.CreateNewPracticeHistory(practiceHistory);

                return new ISubmitCodePracticeFunction.Response(totalPass + "/" + testCases.Count(), samplePass + "/" + testCases.Count(t => t.IsHidden.Equals(false)), hiddenPass + "/" + testCases.Count(t => t.IsHidden.Equals(true)), score);
            }

            return new ISubmitCodePracticeFunction.Response(null, null, null, 0);
        }
    }
}
