using learn_programming_services.Businesses.Functions.Courses;
using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class CoursesServices : ICoursesServices
    {
        private readonly ICoursesRepository _coursesRepository;
        private readonly ICourseLevelsServices _coursesLevelsServices;
        private readonly IUserLearnedLessonsServices _userLearnedLessonsServices;
        private readonly IUserStudyCoursesServices _userStudyCoursesServices;
        private readonly IChaptersServices _chaptersServices;
        private readonly ILessonsServices _lessonsServices;
        private readonly IUsersServices _usersServices;
        private readonly ICourseCommentsServices _courseCommentsServices;
        private readonly ICourseReplyCommentsServices _courseReplyCommentsServices;
        private readonly ICourseCommentActionsServices _courseCommentActionsServices;
        private readonly ICourseReplyCommentActionsServices _courseReplyCommentActionsServices;
        private readonly IConfiguration _configuration;
        private readonly ICourseVotesServices _courseVotesServices;

        public CoursesServices(ICoursesRepository coursesRepository,
            ICourseLevelsServices coursesLevelsServices,
            IUserLearnedLessonsServices userLearnedLessonsServices,
            IUserStudyCoursesServices userStudyCoursesServices,
            IChaptersServices chaptersServices,
            ILessonsServices lessonsServices,
            IUsersServices usersServices,
            ICourseCommentsServices courseCommentsServices,
            ICourseReplyCommentsServices courseReplyCommentsServices,
            ICourseCommentActionsServices courseCommentActionsServices,
            ICourseReplyCommentActionsServices courseReplyCommentActionsServices,
            IConfiguration configuration,
            ICourseVotesServices courseVotesServices)
        {
            _coursesRepository = coursesRepository;
            _coursesLevelsServices = coursesLevelsServices;
            _userLearnedLessonsServices = userLearnedLessonsServices;
            _userStudyCoursesServices = userStudyCoursesServices;
            _chaptersServices = chaptersServices;
            _lessonsServices = lessonsServices;
            _usersServices = usersServices;
            _courseCommentsServices = courseCommentsServices;
            _courseReplyCommentsServices = courseReplyCommentsServices;
            _courseCommentActionsServices = courseCommentActionsServices;
            _courseReplyCommentActionsServices = courseReplyCommentActionsServices;
            _configuration = configuration;
            _courseVotesServices = courseVotesServices;
        }

        public async Task<IEnumerable<Courses>> GetAllCourses()
        {
            return await _coursesRepository.getAllCourses();
        }

        public async Task<IEnumerable<IGetCoursesFunction.CoursesList>> GetCourses(IGetCoursesFunction.Request request)
        {
            var courses = await _coursesRepository.getAllCourses();
            var courseLevels = await _coursesLevelsServices.GetAllCourseLevels();
            var userLearnedLessons = await _userLearnedLessonsServices.GetAllUserLearnedLessons();
            var userStudyCourses = await _userStudyCoursesServices.GetAllUserStudyCourses();
            var chapters = await _chaptersServices.GetAllChapters();
            var lessons = await _lessonsServices.GetAllLessons();
            var users = await _usersServices.GetAllUsers();
            var courseVotes = await _courseVotesServices.GetAllCourseVotes();

            List<IGetCoursesFunction.CoursesList> coursesList = new List<IGetCoursesFunction.CoursesList>();

            foreach (var courseLevel in courseLevels)
            {
                List<IGetCoursesFunction.CourseData> courseData = new List<IGetCoursesFunction.CourseData>();

                var coursesByLevel = courses
                    .Where(c => c.CourseLevelId.Equals(courseLevel.Id))
                    .Where(c => c.IsDeleted.Equals(false))
                    .Where(c => c.IsHidden.Equals(false))
                    .OrderByDescending(c => c.CreateDate)
                    .ToList();

                if(request.keyword != null && request.keyword != "")
                {
                    coursesByLevel = coursesByLevel
                        .Where(c => c.Name.ToLower().Contains(request.keyword.ToLower().Trim()))
                        .ToList();
                }

                if (coursesByLevel != null && coursesByLevel.Count() > 0)
                {
                    foreach (var item in coursesByLevel)
                    {
                        var voteInCourse = courseVotes.Where(c => c.CourseId.Equals(item.Id)).ToList();

                        float voteScore = 0;

                        if (voteInCourse.Count > 0)
                        {
                            voteScore = float.Parse(Math.Round(voteInCourse.Average(v => v.Score), 1).ToString());
                        }

                        IGetCoursesFunction.CourseData data = new IGetCoursesFunction.CourseData()
                        {
                            id = item.Id,
                            courseName = item.Name,
                            authorName = users.Where(u => u.Id.Equals(item.AuthorId)).Select(s => s.UserName).SingleOrDefault(),
                            description = item.Description,
                            voteScore = voteScore,
                            image = item.Image,
                        };

                        var isRegistered = userStudyCourses
                            .Where(u => u.UserId.Equals(request.userId))
                            .Where(u => u.CourseId.Equals(item.Id))
                            .SingleOrDefault();

                        if (isRegistered != null)
                        {
                            var lessonsLearnedByCourse = userLearnedLessons
                                .Where(u => u.UserId.Equals(request.userId))
                                .Where(u => u.CourseId.Equals(item.Id))
                                .Join(chapters,
                                lessonLearned => lessonLearned.ChapterId,
                                chapter => chapter.Id,
                                (lessonLearned, chapter) => new { lessonLearned, chapter })
                                .Where(s => s.chapter.IsDeleted.Equals(false))
                                .Where(s => s.chapter.IsHidden.Equals(false))
                                .Join(lessons,
                                lessonLearned_chapter => lessonLearned_chapter.lessonLearned.LessonId,
                                lesson => lesson.Id,
                                (lessonLearned_chapter, lesson) => new { lessonLearned_chapter, lesson })
                                .Where(s => s.lesson.IsDeleted.Equals(false))
                                .Where(s => s.lesson.IsHidden.Equals(false))
                                .ToList();

                            var lessonsByCourse = chapters
                                .Where(c => c.CourseId.Equals(item.Id))
                                .Where(c => c.IsDeleted.Equals(false))
                                .Where(c => c.IsHidden.Equals(false))
                                .Join(lessons,
                                chapter => chapter.Id,
                                lesson => lesson.ChapterId,
                                (chapter, lesson) => new { chapter, lesson })
                                .Where(s => s.lesson.IsDeleted.Equals(false))
                                .Where(s => s.lesson.IsHidden.Equals(false))
                                .ToList();

                            data.isRegistered = true;
                            data.completedPercent = int.Parse(Math.Round(((float)lessonsLearnedByCourse.Count() / lessonsByCourse.Count()) * 100).ToString());
                        }
                        else
                        {
                            data.isRegistered = false;
                            data.completedPercent = 0;
                        }

                        courseData.Add(data);
                    }
                }

                IGetCoursesFunction.CoursesList courseList = new IGetCoursesFunction.CoursesList()
                {
                    courseLevelId = courseLevel.Id,
                    courseLevelName = courseLevel.Name,
                    courses = courseData
                };

                coursesList.Add(courseList);
            }

            return coursesList;
        }

        public async Task<IGetCourseDetailsFunction.Response> GetCourseDetails(IGetCourseDetailsFunction.Request request)
        {
            var courses = await _coursesRepository.getAllCourses();
            var userLearnedLessons = await _userLearnedLessonsServices.GetAllUserLearnedLessons();
            var userStudyCourses = await _userStudyCoursesServices.GetAllUserStudyCourses();
            var chapters = await _chaptersServices.GetAllChapters();
            var lessons = await _lessonsServices.GetAllLessons();
            var users = await _usersServices.GetAllUsers();
            var courseComments = await _courseCommentsServices.GetAllCourseComments();
            var courseReplyComments = await _courseReplyCommentsServices.GetAllCourseReplyComments();
            var courseVotes = await _courseVotesServices.GetAllCourseVotes();

            var courseDetails = courses
                .Where(c => c.IsDeleted.Equals(false))
                .Where(c => c.IsHidden.Equals(false))
                .Where(c => c.Id.Equals(request.courseId))
                .SingleOrDefault();

            if(courseDetails != null) 
            {
                var authorName = users.Where(u => u.Id.Equals(courseDetails.AuthorId)).Select(s => s.UserName).SingleOrDefault();

                var chaptersInCourse = chapters
                    .Where(c => c.CourseId.Equals(courseDetails.Id))
                    .Where(c => c.IsDeleted.Equals(false))
                    .Where(c => c.IsHidden.Equals(false))
                    .ToList();

                var i = 1;

                var userInCourse = userStudyCourses.Where(u => u.CourseId.Equals(courseDetails.Id)).ToList();

                var voteInCourse = courseVotes.Where(c => c.CourseId.Equals(courseDetails.Id)).ToList();

                float voteScore = 0;

                if(voteInCourse.Count > 0)
                {
                    voteScore = float.Parse(Math.Round(voteInCourse.Average(v => v.Score), 1).ToString());
                }

                List<IGetCourseDetailsFunction.ChapterData> chaptersList = new List<IGetCourseDetailsFunction.ChapterData>();

                IGetCourseDetailsFunction.Response response = null;

                var userRegisterCourse = userStudyCourses
                    .Where(u => u.UserId.Equals(request.userId))
                    .Where(u => u.CourseId.Equals(courseDetails.Id))
                    .SingleOrDefault();

                if(userRegisterCourse != null)
                {
                    foreach (var chapter in chaptersInCourse)
                    {
                        var lessonsInChapter = lessons
                            .Where(lesson => lesson.ChapterId.Equals(chapter.Id))
                            .Where(lesson => lesson.IsDeleted.Equals(false))
                            .Where(lesson => lesson.IsHidden.Equals(false))
                            .ToList();

                        List<IGetCourseDetailsFunction.LessonData> lessonsList = new List<IGetCourseDetailsFunction.LessonData>();

                        foreach (var lesson in lessonsInChapter)
                        {
                            IGetCourseDetailsFunction.LessonData lessonData = new IGetCourseDetailsFunction.LessonData()
                            {
                                id = lesson.Id,
                                lessonNumber = i,
                            };

                            var lessonLearned = userLearnedLessons
                                .Where(u => u.UserId.Equals(request.userId))
                                .Where(u => u.LessonId.Equals(lesson.Id))
                                .SingleOrDefault();

                            if (lessonLearned != null)
                            {
                                lessonData.isLearned = true;
                            }
                            else
                            {
                                lessonData.isLearned = false;
                            }

                            lessonsList.Add(lessonData);

                            i++;
                        }

                        IGetCourseDetailsFunction.ChapterData chapterData = new IGetCourseDetailsFunction.ChapterData()
                        {
                            id = chapter.Id,
                            name = chapter.Name,
                            lessons = lessonsList
                        };

                        chaptersList.Add(chapterData);
                    }

                    var lessonsLearnedByCourse = userLearnedLessons
                        .Where(u => u.UserId.Equals(request.userId))
                        .Where(u => u.CourseId.Equals(courseDetails.Id))
                        .Join(chapters,
                        lessonLearned => lessonLearned.ChapterId,
                        chapter => chapter.Id,
                        (lessonLearned, chapter) => new { lessonLearned, chapter })
                        .Where(s => s.chapter.IsDeleted.Equals(false))
                        .Where(s => s.chapter.IsHidden.Equals(false))
                        .Join(lessons,
                        lessonLearned_chapter => lessonLearned_chapter.lessonLearned.LessonId,
                        lesson => lesson.Id,
                        (lessonLearned_chapter, lesson) => new { lessonLearned_chapter, lesson })
                        .Where(s => s.lesson.IsDeleted.Equals(false))
                        .Where(s => s.lesson.IsHidden.Equals(false))
                        .ToList();

                    var lessonsByCourse = chapters
                        .Where(c => c.CourseId.Equals(courseDetails.Id))
                        .Where(c => c.IsDeleted.Equals(false))
                        .Where(c => c.IsHidden.Equals(false))
                        .Join(lessons,
                        chapter => chapter.Id,
                        lesson => lesson.ChapterId,
                        (chapter, lesson) => new { chapter, lesson })
                        .Where(s => s.lesson.IsDeleted.Equals(false))
                        .Where(s => s.lesson.IsHidden.Equals(false))
                        .ToList();

                    int completedPercent = 0;

                    if (lessonsByCourse != null && lessonsByCourse.Count() > 0)
                    {
                        completedPercent = int.Parse(Math.Round(((float)lessonsLearnedByCourse.Count() / lessonsByCourse.Count()) * 100).ToString());
                    }

                    if(completedPercent.Equals(100) && userRegisterCourse.IsCompleted.Equals(false))
                    {
                        userRegisterCourse.IsCompleted = true;
                        userRegisterCourse.CompletedDate = DateTime.UtcNow;
                        userRegisterCourse.UpdateDate = DateTime.UtcNow;

                        await _userStudyCoursesServices.UpdateUserStudyCourse(userRegisterCourse);
                    }

                    DateTime? completedDate = null;
                    if (userRegisterCourse.CompletedDate.HasValue)
                    {
                        completedDate = userRegisterCourse.CompletedDate.GetValueOrDefault().ToLocalTime();
                    }

                    response = new IGetCourseDetailsFunction.Response(courseDetails.Id, courseDetails.Name, authorName, courseDetails.Description, courseDetails.Objective, courseDetails.Reward, courseDetails.Time, courseDetails.Theme, userInCourse.Count(), voteScore, voteInCourse.Count(), i - 1, true, userRegisterCourse.IsCompleted, completedDate, completedPercent, 0, chaptersList);
                }

                else
                {
                    foreach (var chapter in chaptersInCourse)
                    {
                        var lessonsInChapter = lessons
                            .Where(lesson => lesson.ChapterId.Equals(chapter.Id))
                            .Where(lesson => lesson.IsDeleted.Equals(false))
                            .Where(lesson => lesson.IsHidden.Equals(false))
                            .ToList();

                        List<IGetCourseDetailsFunction.LessonData> lessonsList = new List<IGetCourseDetailsFunction.LessonData>();

                        foreach (var lesson in lessonsInChapter)
                        {
                            IGetCourseDetailsFunction.LessonData lessonData = new IGetCourseDetailsFunction.LessonData()
                            {
                                id = lesson.Id,
                                lessonNumber = i,
                                isLearned = false
                            };

                            lessonsList.Add(lessonData);

                            i++;
                        }

                        IGetCourseDetailsFunction.ChapterData chapterData = new IGetCourseDetailsFunction.ChapterData()
                        {
                            id = chapter.Id,
                            name = chapter.Name,
                            lessons = lessonsList
                        };

                        chaptersList.Add(chapterData);
                    }
                    
                    response = new IGetCourseDetailsFunction.Response(courseDetails.Id, courseDetails.Name, authorName, courseDetails.Description, courseDetails.Objective, courseDetails.Reward, courseDetails.Time, courseDetails.Theme, userInCourse.Count(), voteScore, voteInCourse.Count(), i - 1, false, false, null, 0, 0, chaptersList);
                }

                var comments = courseComments
                        .Where(c => c.CourseId.Equals(request.courseId))
                        .Where(c => c.IsDeleted.Equals(false))
                        .ToList();

                int totalComments = comments.Count();

                foreach (var comment in comments)
                {
                    var replyComments = courseReplyComments
                        .Where(c => c.CourseCommentId.Equals(comment.Id))
                        .Where(c => c.IsDeleted.Equals(false))
                        .ToList();

                    if (replyComments != null && replyComments.Count() > 0)
                    {
                        totalComments += replyComments.Count();
                    }
                }

                response.totalComments = totalComments;
                return response;
            }

            return new IGetCourseDetailsFunction.Response();
        }

        public async Task<ICourseRegisterFunction.Response> CourseRegister(ICourseRegisterFunction.Request request)
        {
            var course = await _coursesRepository.findCourseById(request.courseRegister.courseId);

            if(course != null && course.IsDeleted.Equals(false) && course.IsHidden.Equals(false))
            {
                var userStudyCourse = await _userStudyCoursesServices.FindUserStudyCourseByCourseIdAndUserId(request.courseRegister.courseId, request.courseRegister.userId);

                if(userStudyCourse == null)
                {
                    UserStudyCourses userStudyCourseData = new UserStudyCourses()
                    {
                        UserId = request.courseRegister.userId,
                        CourseId = request.courseRegister.courseId,
                        IsCompleted = false,
                        CreateDate = DateTime.UtcNow,
                        UpdateDate = DateTime.UtcNow,
                    };

                    await _userStudyCoursesServices.CreateNewUserStudyCourse(userStudyCourseData);

                    return new ICourseRegisterFunction.Response(true, null);
                }

                return new ICourseRegisterFunction.Response(false, "This course has registered");
            }

            return new ICourseRegisterFunction.Response(false, "This course does not exist");
        }

        public async Task<ICourseCommentFunction.Response> CourseComment(ICourseCommentFunction.Request request)
        {
            var course = await _coursesRepository.findCourseById(request.courseComment.courseId);

            if (course != null && course.IsDeleted.Equals(false) && course.IsHidden.Equals(false))
            {
                CourseComments courseComment = new CourseComments()
                {
                    Content = request.courseComment.content.Trim(),
                    IsDeleted = false,
                    CourseId = request.courseComment.courseId,
                    AuthorId = request.courseComment.userId,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow,
                };

                await _courseCommentsServices.CreateNewCourseComment(courseComment);

                return new ICourseCommentFunction.Response(true, null);
            }

            return new ICourseCommentFunction.Response(false, "This course does not exist");
        }

        public async Task<ICourseReplyCommentFunction.Response> CourseReplyComment(ICourseReplyCommentFunction.Request request)
        {
            var courseComment = await _courseCommentsServices.FindCourseCommentById(request.courseReplyComment.courseCommentId);

            if(courseComment != null && courseComment.IsDeleted.Equals(false))
            {
                CourseReplyComments courseReplyComment = new CourseReplyComments()
                {
                    Content = request.courseReplyComment.content.Trim(),
                    IsDeleted = false,
                    CourseCommentId = request.courseReplyComment.courseCommentId,
                    AuthorId = request.courseReplyComment.userId,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow,
                };

                await _courseReplyCommentsServices.CreateNewCourseReplyComment(courseReplyComment);

                return new ICourseReplyCommentFunction.Response(true, null);
            }

            return new ICourseReplyCommentFunction.Response(false, "This comment does not exist");
        }

        public async Task<IGetCourseCommentsFunction.Response> GetCourseComments(IGetCourseCommentsFunction.Request request)
        {
            var courseComments = await _courseCommentsServices.GetAllCourseComments();
            var courseReplyComments = await _courseReplyCommentsServices.GetAllCourseReplyComments();
            var users = await _usersServices.GetAllUsers();
            var courseCommentActions = await _courseCommentActionsServices.GetAllCourseCommentActions();
            var courseReplyCommentActions = await _courseReplyCommentActionsServices.GetAllCourseReplyCommentActions();


            var comments = courseComments
                .Where(c => c.CourseId.Equals(request.courseId))
                .Where(c => c.IsDeleted.Equals(false))
                .OrderByDescending(c => c.Id)
                .ToList();

            List<IGetCourseCommentsFunction.CourseCommentData> commentsList = new List<IGetCourseCommentsFunction.CourseCommentData>();

            foreach (var comment in comments)
            {
                var replyComments = courseReplyComments
                    .Where(c => c.CourseCommentId.Equals(comment.Id))
                    .Where(c => c.IsDeleted.Equals(false))
                    .ToList();

                List<IGetCourseCommentsFunction.CourseReplyCommentData> replyCommentsList = new List<IGetCourseCommentsFunction.CourseReplyCommentData>();

                if (replyComments != null && replyComments.Count() > 0)
                {
                    foreach (var replyComment in replyComments)
                    {
                        var replyCommentAction = courseReplyCommentActions.Where(c => c.CourseReplyCommentId.Equals(replyComment.Id)).ToList();

                        IGetCourseCommentsFunction.CourseReplyCommentData replyCommentData = new IGetCourseCommentsFunction.CourseReplyCommentData()
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

                var commentActions = courseCommentActions.Where(c => c.CourseCommentId.Equals(comment.Id)).ToList();

                IGetCourseCommentsFunction.CourseCommentData commentData = new IGetCourseCommentsFunction.CourseCommentData()
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

            return new IGetCourseCommentsFunction.Response(commentsList);
        }

        public async Task<ICourseCommentActionFunction.Response> CourseCommentAction(ICourseCommentActionFunction.Request request)
        {
            var courseCommentActions = await _courseCommentActionsServices.GetAllCourseCommentActions();

            var commentAction = courseCommentActions
                .Where(c => c.CourseCommentId.Equals(request.courseCommentAction.commentId))
                .Where(c => c.UserId.Equals(request.courseCommentAction.userId)).SingleOrDefault();

            if(commentAction != null)
            {
                switch (request.courseCommentAction.actionId)
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
                        } break;
                    
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
                        }break;
                }

                await _courseCommentActionsServices.UpdateCourseCommentAction(commentAction);

                return new ICourseCommentActionFunction.Response(true, "Your action successful");
            }
            else
            {
                CourseCommentActions courseComment = new CourseCommentActions()
                {
                    CourseCommentId = request.courseCommentAction.commentId,
                    UserId = request.courseCommentAction.userId,
                    IsLiked = false,
                    IsDisliked = false,
                };

                switch (request.courseCommentAction.actionId)
                {
                    case 0:
                        {
                            courseComment.IsLiked = true;
                        }break;
                    
                    case 1:
                        {
                            courseComment.IsDisliked = true;
                        } break;
                }

                await _courseCommentActionsServices.CreateNewCourseCommentAction(courseComment);

                return new ICourseCommentActionFunction.Response(true, "Your action successful");
            }
        }

        public async Task<ICourseReplyCommentActionFunction.Response> CourseReplyCommentAction(ICourseReplyCommentActionFunction.Request request)
        {
            var courseReplyCommentActions = await _courseReplyCommentActionsServices.GetAllCourseReplyCommentActions();

            var replyCommentAction = courseReplyCommentActions
                .Where(c => c.CourseReplyCommentId.Equals(request.courseReplyCommentAction.commentId))
                .Where(c => c.UserId.Equals(request.courseReplyCommentAction.userId)).SingleOrDefault();

            if(replyCommentAction != null)
            {
                switch (request.courseReplyCommentAction.actionId)
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

                await _courseReplyCommentActionsServices.UpdateCourseReplyCommentAction(replyCommentAction);

                return new ICourseReplyCommentActionFunction.Response(true, "Your action successful");
            }
            else
            {
                CourseReplyCommentActions courseReplyComment = new CourseReplyCommentActions()
                {
                    CourseReplyCommentId = request.courseReplyCommentAction.commentId,
                    UserId = request.courseReplyCommentAction.userId,
                    IsLiked = false,
                    IsDisliked = false,
                };

                switch (request.courseReplyCommentAction.actionId)
                {
                    case 0:
                        {
                            courseReplyComment.IsLiked = true;
                        }
                        break;

                    case 1:
                        {
                            courseReplyComment.IsDisliked = true;
                        }
                        break;
                }

                await _courseReplyCommentActionsServices.CreateNewCourseReplyCommentAction(courseReplyComment);

                return new ICourseReplyCommentActionFunction.Response(true, "Your action successful");
            }
        }

        public async Task<ICreateNewCourseFunction.Response> CreateNewCourse(ICreateNewCourseFunction.Request request)
        {
            Courses newCourse = new Courses()
            {
                Name = request.newCourse.courseName.Trim(),
                Description = request.newCourse.description.Trim(),
                Objective = request.newCourse.objective.Trim(),
                Reward = request.newCourse.reward.Trim(),
                Time = request.newCourse.time,
                Image = request.newCourse.courseImage.Trim(),
                Theme = request.newCourse.courseTheme.Trim(),
                IsDeleted = false,
                IsHidden = true,
                CourseLevelId = request.newCourse.courseLevelId,
                AuthorId = request.newCourse.authorId,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow
            };

            await _coursesRepository.createNewCourse(newCourse);

            return new ICreateNewCourseFunction.Response(true, null);
        }
    
        public async Task<IEnumerable<IGetCoursesManagementFunction.CoursesManagementList>> GetCoursesManagement(IGetCoursesManagementFunction.Request request)
        {
            var courses = await _coursesRepository.getAllCourses();
            var courseLevels = await _coursesLevelsServices.GetAllCourseLevels();
            var users = await _usersServices.GetAllUsers();
            var courseVotes = await _courseVotesServices.GetAllCourseVotes();

            List<IGetCoursesManagementFunction.CoursesManagementList> coursesList = new List<IGetCoursesManagementFunction.CoursesManagementList>();

            foreach (var courseLevel in courseLevels)
            {
                List<IGetCoursesManagementFunction.CourseManagementData> courseData = new List<IGetCoursesManagementFunction.CourseManagementData>();

                var coursesByLevel = courses
                    .Where(c => c.CourseLevelId.Equals(courseLevel.Id))
                    .Where(c => c.AuthorId.Equals(request.userId))
                    .Where(c => c.IsDeleted.Equals(false))
                    .OrderByDescending(c => c.CreateDate)
                    .ToList();

                if (request.keyword != null && request.keyword != "")
                {
                    coursesByLevel = coursesByLevel
                        .Where(c => c.Name.ToLower().Contains(request.keyword.ToLower().Trim()))
                        .ToList();
                }

                if (coursesByLevel != null && coursesByLevel.Count() > 0)
                {
                    foreach (var item in coursesByLevel)
                    {
                        var voteInCourse = courseVotes.Where(c => c.CourseId.Equals(item.Id)).ToList();

                        float voteScore = 0;

                        if (voteInCourse.Count > 0)
                        {
                            voteScore = float.Parse(Math.Round(voteInCourse.Average(v => v.Score), 1).ToString());
                        }

                        IGetCoursesManagementFunction.CourseManagementData data = new IGetCoursesManagementFunction.CourseManagementData()
                        {
                            id = item.Id,
                            courseName = item.Name,
                            authorName = users.Where(u => u.Id.Equals(item.AuthorId)).Select(s => s.UserName).SingleOrDefault(),
                            description = item.Description,
                            image = item.Image,
                            theme = item.Theme,
                            voteScore = voteScore,
                            isHidden = item.IsHidden,
                        };

                        courseData.Add(data);
                    }
                }

                IGetCoursesManagementFunction.CoursesManagementList courseList = new IGetCoursesManagementFunction.CoursesManagementList()
                {
                    courseLevelId = courseLevel.Id,
                    courseLevelName = courseLevel.Name,
                    courses = courseData
                };

                coursesList.Add(courseList);
            }

            return coursesList;
        }
    
        public async Task<IDeleteCourseFunction.Response> DeleteCourse(IDeleteCourseFunction.Request request)
        {
            var courseById = await _coursesRepository.findCourseById(request.id);

            if (courseById != null && courseById.IsDeleted.Equals(false))
            {
                courseById.IsDeleted = true;
                courseById.UpdateDate = DateTime.UtcNow;

                await _coursesRepository.updateCourse(courseById);

                return new IDeleteCourseFunction.Response(true, null);
            }

            return new IDeleteCourseFunction.Response(false, "The course is not exist");
        }

        public async Task<IGetCourseDetailsManagementFunction.Response> GetCourseDetailsManagement(IGetCourseDetailsManagementFunction.Request request)
        {
            var courseById = await _coursesRepository.findCourseById(request.id);

            if(courseById != null && courseById.IsDeleted.Equals(false))
            {
                return new IGetCourseDetailsManagementFunction.Response(courseById.Id, courseById.Name, courseById.Description, courseById.Objective, courseById.Reward, courseById.Time, courseById.Image, courseById.Theme, courseById.CourseLevelId, courseById.AuthorId);
            }

            return new IGetCourseDetailsManagementFunction.Response();
        }

        public async Task<IUpdateCourseFunction.Response> UpdateCourse(IUpdateCourseFunction.Request request)
        {
            Courses course = await _coursesRepository.findCourseById(request.course.courseId);
            if(course != null && course.IsDeleted.Equals(false))
            {
                course.Name = request.course.courseName.Trim();
                course.Description = request.course.description.Trim();
                course.Objective = request.course.objective.Trim();
                course.Reward = request.course.reward.Trim();
                course.Time = request.course.time;
                course.Image = request.course.courseImage.Trim();
                course.Theme = request.course.courseTheme.Trim();
                course.CourseLevelId = request.course.courseLevelId;
                course.UpdateDate = DateTime.UtcNow;

                await _coursesRepository.updateCourse(course);

                return new IUpdateCourseFunction.Response(true, null);
            }

            List<string> errors = new List<string>();
            errors.Add("The course is not exist");
            return new IUpdateCourseFunction.Response(false, errors);
        }

        public async Task<IHiddenCourseFunction.Response> HiddenCourse(IHiddenCourseFunction.Request request)
        {
            var course = await _coursesRepository.findCourseById(request.id);

            if (course != null && course.IsDeleted.Equals(false)) 
            {
                if (course.IsHidden.Equals(false))
                {
                    course.IsHidden = true;
                    course.UpdateDate = DateTime.UtcNow;
                }
                else if (course.IsHidden.Equals(true))
                {
                    course.IsHidden = false;
                    course.UpdateDate = DateTime.UtcNow;
                }

                await _coursesRepository.updateCourse(course);

                return new IHiddenCourseFunction.Response(true, null);
            }

            return new IHiddenCourseFunction.Response(false, "The course is not exist");
        }

        public async Task<IDeleteCourseCommentFunction.Response> DeleteCourseComment(IDeleteCourseCommentFunction.Request request)
        {
            var courseComment = await _courseCommentsServices.FindCourseCommentById(request.commentId);

            if (courseComment != null && courseComment.IsDeleted.Equals(false) && courseComment.AuthorId.Equals(request.userId))
            {
                courseComment.IsDeleted = true;
                courseComment.UpdateDate = DateTime.UtcNow;

                await _courseCommentsServices.UpdateCourseComment(courseComment);

                return new IDeleteCourseCommentFunction.Response(true, null);
            }

            return new IDeleteCourseCommentFunction.Response(false, "The comment is not exist");
        }

        public async Task<IDeleteCourseReplyCommentFunction.Response> DeleteCourseReplyComment(IDeleteCourseReplyCommentFunction.Request request)
        {
            var courseReplyComment = await _courseReplyCommentsServices.FindCourseReplyCommentById(request.replyCommentId);

            if (courseReplyComment != null && courseReplyComment.IsDeleted.Equals(false) && courseReplyComment.AuthorId.Equals(request.userId))
            {
                courseReplyComment.IsDeleted = true;
                courseReplyComment.UpdateDate = DateTime.UtcNow;

                await _courseReplyCommentsServices.UpdateCourseReplyComment(courseReplyComment);

                return new IDeleteCourseReplyCommentFunction.Response(true, null);
            }

            return new IDeleteCourseReplyCommentFunction.Response(false, "The reply comment is not exist");
        }
    }
}
