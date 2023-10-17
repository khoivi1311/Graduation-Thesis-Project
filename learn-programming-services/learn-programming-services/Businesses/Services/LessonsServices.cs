using learn_programming_services.Businesses.Functions.Courses;
using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class LessonsServices : ILessonsServices
    {
        private readonly ILessonsRepository _lessonsRepository;
        private readonly ILessonTestCasesServices _lessonTestCasesServices;
        private readonly ILessonCodeSamplesServices _lessonCodeSamplesServices;
        private readonly ICodeLanguagesServices _codeLanguagesServices;
        private readonly ILessonHistoriesServices _lessonHistoriesServices;
        private readonly IChaptersServices _chaptersServices;
        private readonly IUsersServices _usersServices;
        private readonly IJobeServices _jobeServices;
        private readonly IUserLearnedLessonsServices _userLearnedLessonsServices;
        private readonly ILessonCommentsServices _lessonCommentsServices;
        private readonly ILessonReplyCommentsServices _lessonReplyCommentsServices;
        private readonly ILessonCommentActionsServices _lessonCommentActionsServices;
        private readonly ILessonReplyCommentActionsServices _lessonReplyCommentActionsServices;

        public LessonsServices(ILessonsRepository lessonsRepository, 
            ILessonTestCasesServices lessonTestCasesServices, 
            ILessonCodeSamplesServices lessonCodeSamplesServices, 
            ICodeLanguagesServices codeLanguagesServices, 
            ILessonHistoriesServices lessonHistoriesServices, 
            IChaptersServices chaptersServices,
            IUsersServices usersServices,
            IJobeServices jobeServices,
            IUserLearnedLessonsServices userLearnedLessonsServices,
            ILessonCommentsServices lessonCommentsServices,
            ILessonReplyCommentsServices lessonReplyCommentsServices,
            ILessonCommentActionsServices lessonCommentActionsServices,
            ILessonReplyCommentActionsServices lessonReplyCommentActionsServices)
        {
            _lessonsRepository = lessonsRepository;
            _lessonTestCasesServices = lessonTestCasesServices;
            _lessonCodeSamplesServices = lessonCodeSamplesServices;
            _codeLanguagesServices = codeLanguagesServices;
            _lessonHistoriesServices = lessonHistoriesServices;
            _chaptersServices = chaptersServices;
            _usersServices = usersServices;
            _jobeServices = jobeServices;
            _userLearnedLessonsServices = userLearnedLessonsServices;
            _lessonCommentsServices = lessonCommentsServices;
            _lessonReplyCommentsServices = lessonReplyCommentsServices;
            _lessonCommentActionsServices = lessonCommentActionsServices;
            _lessonReplyCommentActionsServices = lessonReplyCommentActionsServices;
        }

        public async Task<IEnumerable<Lessons>> GetAllLessons()
        {
            return await _lessonsRepository.getAllLessons();
        }

        public async Task<ICreateNewLessonFunction.Response> CreateNewLesson(ICreateNewLessonFunction.Request request)
        {
            Lessons lesson = new Lessons() 
            {
                Name = request.newLesson.lessonName.Trim(),
                Content = request.newLesson.content.Trim(),
                Score = request.newLesson.score,
                IsDeleted = false,
                IsHidden = true,
                ChapterId = request.newLesson.chapterId,
                AuthorId = request.newLesson.authorId,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow
            };

            await _lessonsRepository.createNewLesson(lesson);

            var latestLesson = await _lessonsRepository.findLatestLesson();

            foreach(var testCase in request.newLesson.testCases)
            {
                LessonTestCases lessonTestCase = new LessonTestCases()
                {
                    Input = testCase.input.Trim(),
                    ExpectedOutput = testCase.expectedOutput.Trim(),
                    IsHidden = testCase.isHidden,
                    IsDeleted = false,
                    LessonId = latestLesson.Id,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow
                };

                await _lessonTestCasesServices.CreateNewLessonTestCases(lessonTestCase);
            }

            foreach(var codeSample in request.newLesson.codeSamples) 
            {
                LessonCodeSamples data = new LessonCodeSamples()
                {
                    CodeSample = codeSample.codeSample.Trim(),
                    CodeLanguageId = codeSample.codeLanguageId,
                    LessonId = latestLesson.Id,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow
                };

                await _lessonCodeSamplesServices.CreateNewLessonCodeSample(data);
            }

            return new ICreateNewLessonFunction.Response(true, null);
        }

        public async Task<IGetLessonManagementDetailsFunction.Response> GetLessonManagementDetails(IGetLessonManagementDetailsFunction.Request request)
        {
            var lessonDetails = await _lessonsRepository.findLessonById(request.id);

            if (lessonDetails != null && lessonDetails.IsDeleted.Equals(false))
            {
                var codeSamples = await _lessonCodeSamplesServices.FindLessonCodeSamplesByLessonId(lessonDetails.Id);
                var testCases = await _lessonTestCasesServices.FindLessonTestCasesByLessonId(lessonDetails.Id);

                List<IGetLessonManagementDetailsFunction.TestCase> testCasesList = new List<IGetLessonManagementDetailsFunction.TestCase>();

                foreach (var testCase in testCases)
                {
                    if (testCase.IsDeleted.Equals(false))
                    {
                        IGetLessonManagementDetailsFunction.TestCase data = new IGetLessonManagementDetailsFunction.TestCase()
                        {
                            testCaseId = testCase.Id,
                            input = testCase.Input,
                            expectedOutput = testCase.ExpectedOutput,
                            isHidden = testCase.IsHidden,
                        };

                        testCasesList.Add(data);
                    }
                }

                List<IGetLessonManagementDetailsFunction.CodeSample> codeSamplesList = new List<IGetLessonManagementDetailsFunction.CodeSample>();

                foreach (var codeSample in codeSamples)
                {
                    IGetLessonManagementDetailsFunction.CodeSample data = new IGetLessonManagementDetailsFunction.CodeSample()
                    {
                        codeSampleId = codeSample.Id,
                        codeSample = codeSample.CodeSample,
                        codeLanguageId = codeSample.CodeLanguageId,
                    };

                    codeSamplesList.Add(data);
                }

                return new IGetLessonManagementDetailsFunction.Response(lessonDetails.Id, lessonDetails.Name, lessonDetails.Content, lessonDetails.Score, lessonDetails.ChapterId, testCasesList.Where(t => t.isHidden.Equals(false)).Count(), testCasesList.Where(t => t.isHidden.Equals(false)).ToList(), testCasesList.Where(t => t.isHidden.Equals(true)).Count(), testCasesList.Where(t => t.isHidden.Equals(true)).ToList(),  codeSamplesList);
            }

            return new IGetLessonManagementDetailsFunction.Response();
        }

        public async Task<IGetLessonDetailsFunction.Response> GetLessonDetails(IGetLessonDetailsFunction.Request request)
        {
            var lessonDetails = await _lessonsRepository.findLessonById(request.lessonId);

            if (lessonDetails != null && lessonDetails.IsDeleted.Equals(false) && lessonDetails.IsHidden.Equals(false))
            {
                var codeSamples = await _lessonCodeSamplesServices.FindLessonCodeSamplesByLessonId(lessonDetails.Id);
                var testCases = await _lessonTestCasesServices.FindLessonTestCasesByLessonId(lessonDetails.Id);
                var codeLanguages = await _codeLanguagesServices.GetAllCodeLanguages();
                var chapter = await _chaptersServices.FindChapterById(lessonDetails.ChapterId);
                var user = await _usersServices.FindUserById(lessonDetails.AuthorId);
                var histories = await _lessonHistoriesServices.FindLessonHistoryByUserIdAndLessonId(request.userId, lessonDetails.Id);

                List<IGetLessonDetailsFunction.TestCase> testCasesList = new List<IGetLessonDetailsFunction.TestCase>();

                foreach (var testCase in testCases)
                {
                    if (testCase.IsDeleted.Equals(false))
                    {
                        IGetLessonDetailsFunction.TestCase data;

                        if (testCase.IsHidden)
                        {
                            data = new IGetLessonDetailsFunction.TestCase()
                            {
                                testCaseId = testCase.Id,
                                input = null,
                                expectedOutput = null,
                                isHidden = testCase.IsHidden,
                            };
                        }
                        else
                        {
                            data = new IGetLessonDetailsFunction.TestCase()
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

                List<IGetLessonDetailsFunction.CodeSample> codeSamplesList = new List<IGetLessonDetailsFunction.CodeSample>();

                foreach (var codeSample in codeSamples)
                {
                    IGetLessonDetailsFunction.CodeSample data = new IGetLessonDetailsFunction.CodeSample()
                    {
                        codeSample = codeSample.CodeSample,
                        codeLanguageName = codeLanguages.FirstOrDefault(c => c.Id.Equals(codeSample.CodeLanguageId)).Name,
                        codeLanguageVersion = codeLanguages.FirstOrDefault(c => c.Id.Equals(codeSample.CodeLanguageId)).Version,
                        codeLanguageId = codeSample.CodeLanguageId,
                        isSubmitted = false,
                    };

                    codeSamplesList.Add(data);
                }

                if (histories != null && histories.Count() > 0)
                {
                    var history = histories.OrderByDescending(h => h.SubmittedDate).FirstOrDefault();

                    foreach (var codeSample in codeSamplesList)
                    {
                        if (history.CodeLanguageId.Equals(codeSample.codeLanguageId))
                        {
                            codeSample.codeSample = history.CodeSubmitted;
                            codeSample.isSubmitted = true;
                        }
                    }
                }

                return new IGetLessonDetailsFunction.Response(lessonDetails.Id, lessonDetails.Name, lessonDetails.Content, lessonDetails.Score, chapter.Name, user.UserName, testCasesList, codeSamplesList);
            }
            
            return new IGetLessonDetailsFunction.Response();
        }

        public async Task<IUpdateLessonFunction.Response> UpdateLesson(IUpdateLessonFunction.Request request)
        {
            var lesson = await _lessonsRepository.findLessonById(request.lesson.lessonId);

            if(lesson != null && lesson.IsDeleted.Equals(false))
            {
                lesson.Name = request.lesson.lessonName.Trim();
                lesson.Content = request.lesson.content.Trim();
                lesson.Score = request.lesson.score;
                lesson.UpdateDate = DateTime.UtcNow;

                await _lessonsRepository.updateLesson(lesson);

                var codeSamples = await _lessonCodeSamplesServices.FindLessonCodeSamplesByLessonId(lesson.Id);
                
                foreach(var codeSample in request.lesson.codeSamples) 
                {
                    bool isUpdated = false;

                    foreach (var item in codeSamples)
                    {
                        if (codeSample.codeSampleId.Equals(item.Id))
                        {
                            item.CodeLanguageId = codeSample.codeLanguageId;
                            item.CodeSample = codeSample.codeSample.Trim();
                            item.UpdateDate = DateTime.UtcNow;

                            isUpdated = true;

                            await _lessonCodeSamplesServices.UpdateLessonCodeSample(item);

                            break;
                        }
                    }

                    if (!isUpdated)
                    {
                        LessonCodeSamples data = new LessonCodeSamples()
                        {
                            CodeSample = codeSample.codeSample.Trim(),
                            CodeLanguageId = codeSample.codeLanguageId,
                            LessonId = lesson.Id,
                            CreateDate = DateTime.UtcNow,
                            UpdateDate = DateTime.UtcNow
                        };

                        await _lessonCodeSamplesServices.CreateNewLessonCodeSample(data);
                    }
                }

                var testCases = await _lessonTestCasesServices.FindLessonTestCasesByLessonId(lesson.Id);
                
                foreach (var testCase in request.lesson.testCases)
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

                            await _lessonTestCasesServices.UpdateLessonTestCase(item);

                            break;
                        }
                    }

                    if (!isUpdated)
                    {
                        LessonTestCases lessonTestCase = new LessonTestCases()
                        {
                            Input = testCase.input.Trim(),
                            ExpectedOutput = testCase.expectedOutput.Trim(),
                            IsHidden = testCase.isHidden,
                            IsDeleted = false,
                            LessonId = lesson.Id,
                            CreateDate = DateTime.UtcNow,
                            UpdateDate = DateTime.UtcNow
                        };

                        await _lessonTestCasesServices.CreateNewLessonTestCases(lessonTestCase);
                    }
                }

                return new IUpdateLessonFunction.Response(true, null);
            }

            return new IUpdateLessonFunction.Response(false, "The lesson is not exist");
        }

        public async Task<IDeleteLessonFunction.Response> DeleteLesson(IDeleteLessonFunction.Request request)
        {
            var lesson = await _lessonsRepository.findLessonById(request.id);

            if (lesson != null && lesson.IsDeleted.Equals(false))
            {
                lesson.IsDeleted = true;
                lesson.UpdateDate = DateTime.UtcNow;

                await _lessonsRepository.updateLesson(lesson);

                return new IDeleteLessonFunction.Response(true, null);
            }

            return new IDeleteLessonFunction.Response(false, "The lesson is not exist");
        }

        public async Task<IHiddenLessonFunction.Response> HiddenLesson(IHiddenLessonFunction.Request request)
        {
            var lesson = await _lessonsRepository.findLessonById(request.id);

            if (lesson != null && lesson.IsDeleted.Equals(false))
            {
                if (lesson.IsHidden.Equals(false))
                {
                    lesson.IsHidden = true;
                    lesson.UpdateDate = DateTime.UtcNow;
                }
                else if (lesson.IsHidden.Equals(true))
                {
                    lesson.IsHidden = false;
                    lesson.UpdateDate = DateTime.UtcNow;
                }

                await _lessonsRepository.updateLesson(lesson);

                return new IHiddenLessonFunction.Response(true, null);
            }

            return new IHiddenLessonFunction.Response(false, "The lesson is not exist");
        }

        public async Task<IGetLessonManagementFunction.Response> GetLessonManagement(IGetLessonManagementFunction.Request request)
        {
            var lessons = await _lessonsRepository.getAllLessons();

            var lessonsData = lessons
                .Where(l => l.ChapterId.Equals(request.chapterId))
                .Where(l => l.IsDeleted.Equals(false))
                .ToList();

            if (lessonsData != null && lessonsData.Count()> 0)
            {
                List<IGetLessonManagementFunction.Lesson> lessonsList = new List<IGetLessonManagementFunction.Lesson>();

                foreach( var lesson in lessonsData)
                {
                    IGetLessonManagementFunction.Lesson data = new IGetLessonManagementFunction.Lesson()
                    {
                        lessonId = lesson.Id,
                        lessonName = lesson.Name,
                        score = lesson.Score,
                        isHidden = lesson.IsHidden,
                    };

                    lessonsList.Add(data);
                }

                return new IGetLessonManagementFunction.Response(lessonsList);
            }

            return new IGetLessonManagementFunction.Response();
        }

        public async Task<IRunCodeLessonFunction.Response> RunCodeLesson(IRunCodeLessonFunction.Request request)
        {
            var lesson = await _lessonsRepository.findLessonById(request.runCodeLesson.lessonId);

            if(lesson != null && lesson.IsDeleted.Equals(false) && lesson.IsHidden.Equals(false))
            {
                var codeLanguage = await _codeLanguagesServices.FindCodeLanguageById(request.runCodeLesson.codeLanguageId);
                var testCases = await _lessonTestCasesServices.FindLessonTestCasesByLessonId(lesson.Id);

                testCases = testCases
                    .Where(t => t.IsHidden.Equals(false))
                    .Where(t => t.IsDeleted.Equals(false))
                    .ToList();

                List<IRunCodeLessonFunction.TestCase> resultList = new List<IRunCodeLessonFunction.TestCase>();

                int pass = 0;

                foreach(var testCase in testCases)
                {
                    IJobeServices.JobeDataInput data = new IJobeServices.JobeDataInput()
                    {
                        language_id = codeLanguage.SubmitName,
                        sourcecode = request.runCodeLesson.lessonCode.Trim(),
                        input = testCase.Input
                    };

                    var responseData = await _jobeServices.JobeRun(data);

                    switch (responseData.outcome)
                    {
                        case 11:
                            {
                                return new IRunCodeLessonFunction.Response("0/" + testCases.Count(), "Compilation error", responseData.cmpinfo, null);
                            } break;

                        case 12:
                            {
                                return new IRunCodeLessonFunction.Response("0/" + testCases.Count(), "Runtime error", responseData.stderr, null);
                            } break;

                        case 13:
                            {
                                return new IRunCodeLessonFunction.Response("0/" + testCases.Count(), "Time limit exceeded", responseData.stderr, null);
                            }

                        case 15:
                            {
                                IRunCodeLessonFunction.TestCase testCaseData = new IRunCodeLessonFunction.TestCase()
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
                            } break;

                        case 17:
                            {
                                return new IRunCodeLessonFunction.Response("0/" + testCases.Count(), "Memory limit exceeded", responseData.stderr, null);
                            } break;

                        case 19:
                            {
                                return new IRunCodeLessonFunction.Response("0/" + testCases.Count(), "Illegal system call", responseData.stderr, null);
                            } break;

                        case 20:
                            {
                                return new IRunCodeLessonFunction.Response("0/" + testCases.Count(), "Internal error", responseData.stderr, null);
                            }
                            break;

                        case 21:
                            {
                                return new IRunCodeLessonFunction.Response("0/" + testCases.Count(), "Server overload", responseData.stderr, null);
                            }
                            break;
                    }
                }

                return new IRunCodeLessonFunction.Response(pass + "/" + testCases.Count(), null, null, resultList);
            }

            return new IRunCodeLessonFunction.Response(null, "Lesson error", "The lesson is not exist", null);
        }

        public async Task<ISubmitCodeLessonFunction.Response> SubmitCodeLesson(ISubmitCodeLessonFunction.Request request)
        {
            var lesson = await _lessonsRepository.findLessonById(request.submitCodeLesson.lessonId);

            if (lesson != null && lesson.IsDeleted.Equals(false) && lesson.IsHidden.Equals(false))
            {
                var codeLanguage = await _codeLanguagesServices.FindCodeLanguageById(request.submitCodeLesson.codeLanguageId);
                var testCases = await _lessonTestCasesServices.FindLessonTestCasesByLessonId(lesson.Id);
                var chapter = await _chaptersServices.FindChapterById(lesson.ChapterId);

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
                        sourcecode = request.submitCodeLesson.lessonCode.Trim(),
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


                int score = int.Parse(Math.Round((totalPass) * ((float)lesson.Score / testCases.Count())).ToString());

                LessonHistories lessonHistory = new LessonHistories()
                {
                    TestCase = totalPass + "/" + testCases.Count(),
                    Score = score,
                    CodeSubmitted = request.submitCodeLesson.lessonCode.Trim(),
                    SubmittedDate = DateTime.UtcNow,
                    LessonId = lesson.Id,
                    AuthorId = request.submitCodeLesson.userId,
                    CodeLanguageId = codeLanguage.Id
                };
                
                await _lessonHistoriesServices.CreateNewLessonHistory(lessonHistory);

                var userLearned = await _userLearnedLessonsServices.FindUserLearnedLessonByUserIdLessonId(request.submitCodeLesson.userId, lesson.Id);

                if (totalPass.Equals(testCases.Count()) && userLearned == null)
                {
                    UserLearnedLessons userLearnedLesson = new UserLearnedLessons()
                    {
                        UserId = request.submitCodeLesson.userId,
                        CourseId = chapter.CourseId,
                        ChapterId = chapter.Id,
                        LessonId = lesson.Id,
                        CreateDate = DateTime.UtcNow,
                        UpdateDate = DateTime.UtcNow
                    };

                    await _userLearnedLessonsServices.CreateNewUserLearnedLesson(userLearnedLesson);
                }

                return new ISubmitCodeLessonFunction.Response(totalPass + "/" + testCases.Count(), samplePass + "/" + testCases.Count(t => t.IsHidden.Equals(false)), hiddenPass + "/" + testCases.Count(t => t.IsHidden.Equals(true)), score);
            }

            return new ISubmitCodeLessonFunction.Response(null, null, null, 0);
        }

        public async Task<ILessonCommentFunction.Response> LessonComment(ILessonCommentFunction.Request request)
        {
            var lesson = await _lessonsRepository.findLessonById(request.lessonComment.lessonId);

            if (lesson != null && lesson.IsDeleted.Equals(false) && lesson.IsHidden.Equals(false))
            {
                LessonComments lessonComment = new LessonComments()
                {
                    Content = request.lessonComment.content.Trim(),
                    IsDeleted = false,
                    LessonId = request.lessonComment.lessonId,
                    AuthorId = request.lessonComment.userId,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow,
                };

                await _lessonCommentsServices.CreateNewLessonComment(lessonComment);

                return new ILessonCommentFunction.Response(true, null);
            }

            return new ILessonCommentFunction.Response(false, "This lesson does not exist");
        }

        public async Task<ILessonReplyCommentFunction.Response> LessonReplyComment(ILessonReplyCommentFunction.Request request)
        {
            var lessonComment = await _lessonCommentsServices.FindLessonCommentById(request.lessonReplyComment.lessonCommentId);

            if (lessonComment != null && lessonComment.IsDeleted.Equals(false))
            {
                LessonReplyComments lessonReplyComment = new LessonReplyComments()
                {
                    Content = request.lessonReplyComment.content.Trim(),
                    IsDeleted = false,
                    LessonCommentId = request.lessonReplyComment.lessonCommentId,
                    AuthorId = request.lessonReplyComment.userId,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow,
                };

                await _lessonReplyCommentsServices.CreateNewLessonReplyComment(lessonReplyComment);

                return new ILessonReplyCommentFunction.Response(true, null);
            }

            return new ILessonReplyCommentFunction.Response(false, "This comment does not exist");
        }

        public async Task<IGetLessonCommentsFunction.Response> GetLessonComments(IGetLessonCommentsFunction.Request request)
        {
            var lessonComments = await _lessonCommentsServices.GetAllLessonComments();
            var lessonReplyComments = await _lessonReplyCommentsServices.GetAllLessonReplyComments();
            var users = await _usersServices.GetAllUsers();
            var lessonCommentActions = await _lessonCommentActionsServices.GetAllLessonCommentActions();
            var lessonReplyCommentActions = await _lessonReplyCommentActionsServices.GetAllLessonReplyCommentActions();


            var comments = lessonComments
                .Where(c => c.LessonId.Equals(request.lessonId))
                .Where(c => c.IsDeleted.Equals(false))
                .OrderByDescending(c => c.Id)
                .ToList();

            List<IGetLessonCommentsFunction.LessonCommentData> commentsList = new List<IGetLessonCommentsFunction.LessonCommentData>();

            foreach (var comment in comments)
            {
                var replyComments = lessonReplyComments
                    .Where(c => c.LessonCommentId.Equals(comment.Id))
                    .Where(c => c.IsDeleted.Equals(false))
                    .ToList();

                List<IGetLessonCommentsFunction.LessonReplyCommentData> replyCommentsList = new List<IGetLessonCommentsFunction.LessonReplyCommentData>();

                if (replyComments != null && replyComments.Count() > 0)
                {
                    foreach (var replyComment in replyComments)
                    {
                        var replyCommentAction = lessonReplyCommentActions.Where(c => c.LessonReplyCommentId.Equals(replyComment.Id)).ToList();

                        IGetLessonCommentsFunction.LessonReplyCommentData replyCommentData = new IGetLessonCommentsFunction.LessonReplyCommentData()
                        {
                            commentId = replyComment.Id,
                            content = replyComment.Content,
                            authorId = replyComment.AuthorId,
                            authorName = users.Where(u => u.Id.Equals(replyComment.AuthorId)).Select(s => s.UserName).SingleOrDefault(),
                            numberOfLike = replyCommentAction.Where(c => c.IsLiked.Equals(true)).Count(),
                            isLiked = replyCommentAction.Where(c => c.UserId.Equals(request.userId)).Where(c => c.IsLiked.Equals(true)).Select(s => s.IsLiked).SingleOrDefault(),
                            numberOfDislike = replyCommentAction.Where(c => c.IsDisliked.Equals(true)).Count(),
                            isDisliked = replyCommentAction.Where(c => c.UserId.Equals(request.userId)).Where(c => c.IsDisliked.Equals(true)).Select(s => s.IsDisliked).SingleOrDefault(),
                            commentDate = replyComment.CreateDate.ToLocalTime()
                        };

                        replyCommentsList.Add(replyCommentData);
                    }
                }

                var commentActions = lessonCommentActions.Where(c => c.LessonCommentId.Equals(comment.Id)).ToList();

                IGetLessonCommentsFunction.LessonCommentData commentData = new IGetLessonCommentsFunction.LessonCommentData()
                {
                    commentId = comment.Id,
                    content = comment.Content,
                    authorId = comment.AuthorId,
                    authorName = users.Where(u => u.Id.Equals(comment.AuthorId)).Select(s => s.UserName).SingleOrDefault(),
                    numberOfLike = commentActions.Where(c => c.IsLiked.Equals(true)).Count(),
                    isLiked = commentActions.Where(c => c.UserId.Equals(request.userId)).Where(c => c.IsLiked.Equals(true)).Select(s => s.IsLiked).SingleOrDefault(),
                    numberOfDislike = commentActions.Where(c => c.IsDisliked.Equals(true)).Count(),
                    isDisliked = commentActions.Where(c => c.UserId.Equals(request.userId)).Where(c => c.IsDisliked.Equals(true)).Select(s => s.IsDisliked).SingleOrDefault(),
                    commentDate = comment.CreateDate.ToLocalTime(),
                    replyComments = replyCommentsList
                };

                commentsList.Add(commentData);
            }

            return new IGetLessonCommentsFunction.Response(commentsList);
        }

        public async Task<ILessonCommentActionFunction.Response> LessonCommentAction(ILessonCommentActionFunction.Request request)
        {
            var lessonCommentActions = await _lessonCommentActionsServices.GetAllLessonCommentActions();

            var commentAction = lessonCommentActions
                .Where(c => c.LessonCommentId.Equals(request.lessonCommentAction.commentId))
                .Where(c => c.UserId.Equals(request.lessonCommentAction.userId)).SingleOrDefault();

            if (commentAction != null)
            {
                switch (request.lessonCommentAction.actionId)
                {
                    case 0:
                        {
                            if (commentAction.IsDisliked)
                            {
                                commentAction.IsDisliked = false;
                            }

                            if (commentAction.IsLiked)
                            {
                                commentAction.IsLiked = false;
                            }
                            else if (!commentAction.IsLiked)
                            {
                                commentAction.IsLiked = true;
                            }
                        }
                        break;

                    case 1:
                        {
                            if (commentAction.IsLiked)
                            {
                                commentAction.IsLiked = false;
                            }

                            if (commentAction.IsDisliked)
                            {
                                commentAction.IsDisliked = false;
                            }
                            else if (!commentAction.IsDisliked)
                            {
                                commentAction.IsDisliked = true;
                            }
                        }
                        break;
                }

                await _lessonCommentActionsServices.UpdateLessonCommentAction(commentAction);

                return new ILessonCommentActionFunction.Response(true, "Your action successful");
            }
            else
            {
                LessonCommentActions lessonComment = new LessonCommentActions()
                {
                    LessonCommentId = request.lessonCommentAction.commentId,
                    UserId = request.lessonCommentAction.userId,
                    IsLiked = false,
                    IsDisliked = false,
                };

                switch (request.lessonCommentAction.actionId)
                {
                    case 0:
                        {
                            lessonComment.IsLiked = true;
                        }
                        break;

                    case 1:
                        {
                            lessonComment.IsDisliked = true;
                        }
                        break;
                }

                await _lessonCommentActionsServices.CreateNewLessonCommentAction(lessonComment);

                return new ILessonCommentActionFunction.Response(true, "Your action successful");
            }
        }

        public async Task<ILessonReplyCommentActionFunction.Response> LessonReplyCommentAction(ILessonReplyCommentActionFunction.Request request)
        {
            var lessonReplyCommentActions = await _lessonReplyCommentActionsServices.GetAllLessonReplyCommentActions();

            var replyCommentAction = lessonReplyCommentActions
                .Where(c => c.LessonReplyCommentId.Equals(request.lessonReplyCommentAction.commentId))
                .Where(c => c.UserId.Equals(request.lessonReplyCommentAction.userId)).SingleOrDefault();

            if (replyCommentAction != null)
            {
                switch (request.lessonReplyCommentAction.actionId)
                {
                    case 0:
                        {
                            if (replyCommentAction.IsDisliked)
                            {
                                replyCommentAction.IsDisliked = false;
                            }

                            if (replyCommentAction.IsLiked)
                            {
                                replyCommentAction.IsLiked = false;
                            }
                            else if (!replyCommentAction.IsLiked)
                            {
                                replyCommentAction.IsLiked = true;
                            }
                        }
                        break;

                    case 1:
                        {
                            if (replyCommentAction.IsLiked)
                            {
                                replyCommentAction.IsLiked = false;
                            }

                            if (replyCommentAction.IsDisliked)
                            {
                                replyCommentAction.IsDisliked = false;
                            }
                            else if (!replyCommentAction.IsDisliked)
                            {
                                replyCommentAction.IsDisliked = true;
                            }
                        }
                        break;
                }

                await _lessonReplyCommentActionsServices.UpdateLessonReplyCommentAction(replyCommentAction);

                return new ILessonReplyCommentActionFunction.Response(true, "Your action successful");
            }
            else
            {
                LessonReplyCommentActions lessonReplyComment = new LessonReplyCommentActions()
                {
                    LessonReplyCommentId = request.lessonReplyCommentAction.commentId,
                    UserId = request.lessonReplyCommentAction.userId,
                    IsLiked = false,
                    IsDisliked = false,
                };

                switch (request.lessonReplyCommentAction.actionId)
                {
                    case 0:
                        {
                            lessonReplyComment.IsLiked = true;
                        }
                        break;

                    case 1:
                        {
                            lessonReplyComment.IsDisliked = true;
                        }
                        break;
                }

                await _lessonReplyCommentActionsServices.CreateNewLessonReplyCommentAction(lessonReplyComment);

                return new ILessonReplyCommentActionFunction.Response(true, "Your action successful");
            }
        }

        public async Task<IDeleteLessonCommentFunction.Response> DeleteLessonComment(IDeleteLessonCommentFunction.Request request)
        {
            var lessonComment = await _lessonCommentsServices.FindLessonCommentById(request.commentId);

            if (lessonComment != null && lessonComment.IsDeleted.Equals(false) && lessonComment.AuthorId.Equals(request.userId))
            {
                lessonComment.IsDeleted = true;
                lessonComment.UpdateDate = DateTime.UtcNow;

                await _lessonCommentsServices.UpdateLessonComment(lessonComment);

                return new IDeleteLessonCommentFunction.Response(true, null);
            }

            return new IDeleteLessonCommentFunction.Response(false, "The comment is not exist");
        }

        public async Task<IDeleteLessonReplyCommentFunction.Response> DeleteLessonReplyComment(IDeleteLessonReplyCommentFunction.Request request)
        {
            var lessonReplyComment = await _lessonReplyCommentsServices.FindLessonReplyCommentById(request.replyCommentId);

            if (lessonReplyComment != null && lessonReplyComment.IsDeleted.Equals(false) && lessonReplyComment.AuthorId.Equals(request.userId))
            {
                lessonReplyComment.IsDeleted = true;
                lessonReplyComment.UpdateDate = DateTime.UtcNow;

                await _lessonReplyCommentsServices.UpdateLessonReplyComment(lessonReplyComment);

                return new IDeleteLessonReplyCommentFunction.Response(true, null);
            }

            return new IDeleteLessonReplyCommentFunction.Response(false, "The reply comment is not exist");
        }
    }
}
