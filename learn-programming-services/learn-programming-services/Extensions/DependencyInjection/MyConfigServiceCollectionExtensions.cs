using learn_programming_services.Businesses.Functions.Authentications;
using learn_programming_services.Businesses.Functions.Contests;
using learn_programming_services.Businesses.Functions.Courses;
using learn_programming_services.Businesses.Functions.Discussions;
using learn_programming_services.Businesses.Functions.Practices;
using learn_programming_services.Businesses.Functions.Users;
using learn_programming_services.Businesses.Services;
using learn_programming_services.Database.Repository;
using learn_programming_services.Utils;

namespace learn_programming_services.Extensions.DependencyInjection
{
    public static class MyConfigServiceCollectionExtensions
    {
        //Add services of Repository
        public static IServiceCollection AddMyRepositoryServicesGroup(this IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUserPermissionsRepository, UserPermissionsRepository>();
            services.AddScoped<IUserTokensRepository, UserTokensRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<ICoursesRepository, CoursesRepository>();
            services.AddScoped<ICourseLevelsRepository, CourseLevelsRepository>();
            services.AddScoped<IUserStudyCoursesRepository, UserStudyCoursesRepository>();
            services.AddScoped<IUserLearnedLessonsRepository, UserLearnedLessonsRepository>();
            services.AddScoped<IChaptersRepository, ChaptersRepository>();
            services.AddScoped<ILessonsRepository, LessonsRepository>();
            services.AddScoped<ICourseCommentsRepository, CourseCommentsRepository>();
            services.AddScoped<ICourseReplyCommentsRepository, CourseReplyCommentsRepository>();
            services.AddScoped<ICourseCommentActionsRepository, CourseCommentActionsRepository>();
            services.AddScoped<ICourseReplyCommentActionsRepository, CourseReplyCommentActionsRepository>();
            services.AddScoped<ICourseVotesRepository, CourseVotesRepository>();
            services.AddScoped<ILessonTestCasesRepository, LessonTestCasesRepository>();
            services.AddScoped<ILessonCodeSamplesRepository, LessonCodeSamplesRepository>();
            services.AddScoped<ILessonHistoriesRepository, LessonHistoriesRepository>();
            services.AddScoped<ICodeLanguagesRepository, CodeLanguagesRepository>();
            services.AddScoped<IThemesRepository, ThemesRepository>();
            services.AddScoped<ILessonCommentsRepository, LessonCommentsRepository>();
            services.AddScoped<ILessonReplyCommentsRepository, LessonReplyCommentsRepository>();
            services.AddScoped<ILessonCommentActionsRepository, LessonCommentActionsRepository>();
            services.AddScoped<ILessonReplyCommentActionsRepository, LessonReplyCommentActionsRepository>();
            services.AddScoped<IContestsRepository, ContestsRepository>();
            services.AddScoped<IContestStatusesRepository, ContestStatusesRepository>();
            services.AddScoped<IUserRegisterContestsRepository, UserRegisterContestsRepository>();
            services.AddScoped<IContestTasksRepository, ContestTasksRepository>();
            services.AddScoped<IContestTaskTestCasesRepository, ContestTaskTestCasesRepository>();
            services.AddScoped<IContestTaskHistoriesRepository, ContestTaskHistoriesRepository>();
            services.AddScoped<IContestTaskCodeLanguagesRepository, ContestTaskCodeLanguagesRepository>();
            services.AddScoped<IPracticesRepository, PracticesRepository>();
            services.AddScoped<IPracticeLevelsRepository, PracticeLevelsRepository>();
            services.AddScoped<IPracticeTestCasesRepository, PracticeTestCasesRepository>();
            services.AddScoped<IPracticeHistoriesRepository, PracticeHistoriesRepository>();
            services.AddScoped<IDiscussionsRepository, DiscussionsRepository>();
            services.AddScoped<IDiscussionCommentsRepository, DiscussionCommentsRepository>();
            services.AddScoped<IDiscussionReplyCommentsRepository, DiscussionReplyCommentsRepository>();
            services.AddScoped<IDiscussionCommentActionsRepository, DiscussionCommentActionsRepository>();
            services.AddScoped<IDiscussionReplyCommentActionsRepository, DiscussionReplyCommentActionsRepository>();

            return services;
        }

        //Add services of Service
        public static IServiceCollection AddMyServiceServicesGroup(this IServiceCollection services)
        {
            services.AddScoped<IUsersServices, UsersServices>();
            services.AddScoped<IAuthenticationServices, AuthenticationServices>();
            services.AddScoped<IUserPermissionsServices, UserPermissionsServices>();
            services.AddScoped<IUserTokensServices, UserTokensServices>();
            services.AddScoped<IRolesServices, RolesServices>();
            services.AddScoped<ICoursesServices, CoursesServices>();
            services.AddScoped<ICourseLevelsServices, CourseLevelsServices>();
            services.AddScoped<IUserStudyCoursesServices, UserStudyCoursesServices>();
            services.AddScoped<IUserLearnedLessonsServices, UserLearnedLessonsServices>();
            services.AddScoped<IChaptersServices, ChaptersServices>();
            services.AddScoped<ILessonsServices, LessonsServices>();
            services.AddScoped<ICourseCommentsServices, CourseCommentsServices>();
            services.AddScoped<ICourseReplyCommentsServices, CourseReplyCommentsServices>();
            services.AddScoped<ICourseCommentActionsServices, CourseCommentActionsServices>();
            services.AddScoped<ICourseReplyCommentActionsServices, CourseReplyCommentActionsServices>();
            services.AddScoped<ICourseVotesServices, CourseVotesServices>();
            services.AddScoped<ILessonTestCasesServices, LessonTestCasesServices>();
            services.AddScoped<ILessonCodeSamplesServices, LessonCodeSamplesServices>();
            services.AddScoped<ILessonHistoriesServices, LessonHistoriesServices>();
            services.AddScoped<ICodeLanguagesServices, CodeLanguagesServices>();
            services.AddScoped<IJobeServices, JobeServices>();
            services.AddScoped<IThemesServices, ThemesServices>();
            services.AddScoped<ILessonCommentsServices, LessonCommentsServices>();
            services.AddScoped<ILessonReplyCommentsServices, LessonReplyCommentsServices>();
            services.AddScoped<ILessonCommentActionsServices, LessonCommentActionsServices>();
            services.AddScoped<ILessonReplyCommentActionsServices, LessonReplyCommentActionsServices>();
            services.AddScoped<IContestsServices, ContestsServices>();
            services.AddScoped<IContestStatusesServices, ContestStatusesServices>();
            services.AddScoped<IUserRegisterContestsServices, UserRegisterContestsServices>();
            services.AddScoped<IContestTasksServices, ContestTasksServices>();
            services.AddScoped<IContestTaskTestCasesServices, ContestTaskTestCasesServices>();
            services.AddScoped<IContestTaskHistoriesServices, ContestTaskHistoriesServices>();
            services.AddScoped<IContestTaskCodeLanguagesServices, ContestTaskCodeLanguagesServices>();
            services.AddScoped<IPracticesServices, PracticesServices>();
            services.AddScoped<IPracticeLevelsServices, PracticeLevelsServices>();
            services.AddScoped<IPracticeTestCasesServices, PracticeTestCasesServices>();
            services.AddScoped<IPracticeHistoriesServices, PracticeHistoriesServices>();
            services.AddScoped<IDiscussionsServices, DiscussionsServices>();
            services.AddScoped<IDiscussionCommentsServices, DiscussionCommentsServices>();
            services.AddScoped<IDiscussionReplyCommentsServices, DiscussionReplyCommentsServices>();
            services.AddScoped<IDiscussionCommentActionsServices, DiscussionCommentActionsServices>();
            services.AddScoped<IDiscussionReplyCommentActionsServices, DiscussionReplyCommentActionsServices>();

            return services;
        }

        //Add services of Util
        public static IServiceCollection AddMyUtilServicesGroup(this IServiceCollection services)
        {
            services.AddScoped<ICommonUtil, CommonUtil>();

            return services;
        }

        //Add services of Authentication Funtion
        public static IServiceCollection AddMyAuthenticationFunctionServicesGroup(this IServiceCollection services)
        {
            services.AddScoped<IRegisterFunction, RegisterFunction>();
            services.AddScoped<ILoginFunction, LoginFunction>();
            services.AddScoped<IRefreshTokenFunction, RefreshTokenFunction>();
            services.AddScoped<ILogoutFunction, LogoutFunction>();

            return services;
        }

        //Add services of User Funtion
        public static IServiceCollection AddMyUserFunctionServicesGroup(this IServiceCollection services)
        {
            services.AddScoped<IGetUserInformationFunction, GetUserInformationFunction>();
            services.AddScoped<IUpdateUserInformationFunction, UpdateUserInformationFunction>();

            return services;
        }

        //Add services of Course Funtion
        public static IServiceCollection AddMyCourseFunctionServicesGroup(this IServiceCollection services)
        {
            services.AddScoped<IGetCoursesFunction, GetCoursesFunction>();
            services.AddScoped<IGetCourseDetailsFunction, GetCourseDetailsFunction>();
            services.AddScoped<ICourseRegisterFunction, CourseRegisterFunction>();
            services.AddScoped<ICourseCommentFunction, CourseCommentFunction>();
            services.AddScoped<ICourseReplyCommentFunction, CourseReplyCommentFunction>();
            services.AddScoped<IGetCourseCommentsFunction, GetCourseCommentsFunction>();
            services.AddScoped<ICourseCommentActionFunction, CourseCommentActionFunction>();
            services.AddScoped<ICourseReplyCommentActionFunction, CourseReplyCommentActionFunction>();
            services.AddScoped<ICreateNewCourseFunction, CreateNewCourseFunction>();
            services.AddScoped<IGetCourseLevelsFunction, GetCourseLevelsFunction>();
            services.AddScoped<ICreateNewChapterFunction, CreateNewChapterFunction>();
            services.AddScoped<IGetCoursesManagementFunction, GetCoursesManagementFunction>();
            services.AddScoped<IDeleteCourseFunction, DeleteCourseFunction>();
            services.AddScoped<IGetCourseDetailsManagementFunction, GetCourseDetailsManagementFunction>();
            services.AddScoped<IUpdateCourseFunction, UpdateCourseFunction>();
            services.AddScoped<IHiddenCourseFunction, HiddenCourseFunction>();
            services.AddScoped<IGetChapterDetailsFunction, GetChapterDetailsFunction>();
            services.AddScoped<IUpdateChapterFunction, UpdateChapterFunction>();
            services.AddScoped<IDeleteChapterFunction, DeleteChapterFunction>();
            services.AddScoped<IHiddenChapterFunction, HiddenChapterFunction>();
            services.AddScoped<ICreateNewLessonFunction, CreateNewLessonFunction>();
            services.AddScoped<IGetLessonManagementDetailsFunction, GetLessonManagementDetailsFunction>();
            services.AddScoped<IGetLessonDetailsFunction, GetLessonDetailsFunction>();
            services.AddScoped<IGetChaptersManagementFunction, GetChaptersManagementFunction>();
            services.AddScoped<IUpdateLessonFunction, UpdateLessonFunction>();
            services.AddScoped<IDeleteLessonFunction, DeleteLessonFunction>();
            services.AddScoped<IHiddenLessonFunction, HiddenLessonFunction>();
            services.AddScoped<IGetLessonManagementFunction, GetLessonManagementFunction>();
            services.AddScoped<IRunCodeLessonFunction, RunCodeLessonFunction>();
            services.AddScoped<ISubmitCodeLessonFunction, SubmitCodeLessonFunction>();
            services.AddScoped<IGetThemesFunction, GetThemesFunction>();
            services.AddScoped<IGetCodeLanguagesFunction, GetCodeLanguagesFunction>();
            services.AddScoped<IGetLessonHistoriesFunction, GetLessonHistoriesFunction>();
            services.AddScoped<ILessonCommentFunction, LessonCommentFunction>();
            services.AddScoped<ILessonReplyCommentFunction, LessonReplyCommentFunction>();
            services.AddScoped<IGetLessonCommentsFunction, GetLessonCommentsFunction>();
            services.AddScoped<ILessonCommentActionFunction, LessonCommentActionFunction>();
            services.AddScoped<ILessonReplyCommentActionFunction, LessonReplyCommentActionFunction>();
            services.AddScoped<IDeleteCourseCommentFunction, DeleteCourseCommentFunction>();
            services.AddScoped<IDeleteCourseReplyCommentFunction, DeleteCourseReplyCommentFunction>();
            services.AddScoped<IDeleteLessonCommentFunction, DeleteLessonCommentFunction>();
            services.AddScoped<IDeleteLessonReplyCommentFunction, DeleteLessonReplyCommentFunction>();
            services.AddScoped<IGetLessonLeaderboardFunction, GetLessonLeaderboardFunction>();
            services.AddScoped<IDeleteLessonTestCaseFunction, DeleteLessonTestCaseFunction>();

            return services;
        }

        //Add services of Contest Funtion
        public static IServiceCollection AddMyContestFunctionServicesGroup(this IServiceCollection services)
        {
            services.AddScoped<IGetContestsManagementFunction, GetContestsManagementFunction>();
            services.AddScoped<IGetContestStatusesFunction, GetContestStatusesFunction>();

            return services;
        }

        //Add services of Practice Funtion
        public static IServiceCollection AddMyPracticeFunctionServicesGroup(this IServiceCollection services)
        {
            services.AddScoped<IGetPracticeLevelsFunction, GetPracticeLevelsFunction>();
            services.AddScoped<ICreateNewPracticeFunction, CreateNewPracticeFunction>();
            services.AddScoped<IGetPracticesManagementFunction, GetPracticesManagementFunction>();
            services.AddScoped<IGetPracticeDetailsManagementFunction, GetPracticeDetailsManagementFunction>();
            services.AddScoped<IDeletePracticeFunction, DeletePracticeFunction>();
            services.AddScoped<IHiddenPracticeFunction, HiddenPracticeFunction>();
            services.AddScoped<IDeletePracticeTestCaseFunction, DeletePracticeTestCaseFunction>();
            services.AddScoped<IUpdatePracticeFunction, UpdatePracticeFunction>();
            services.AddScoped<IGetPracticesFunction, GetPracticesFunction>();
            services.AddScoped<IGetPracticeDetailsFunction, GetPracticeDetailsFunction>();
            services.AddScoped<IRunCodePracticeFunction, RunCodePracticeFunction>();
            services.AddScoped<ISubmitCodePracticeFunction, SubmitCodePracticeFunction>();
            services.AddScoped<IGetPracticeHistoriesFunction, GetPracticeHistoriesFunction>();
            services.AddScoped<IGetPracticeLeaderboardFunction, GetPracticeLeaderboardFunction>();

            return services;
        }

        //Add services of Discussion Funtion
        public static IServiceCollection AddMyDiscussionFunctionServicesGroup(this IServiceCollection services)
        {
            services.AddScoped<ICreateNewDiscussionFunction, CreateNewDiscussionFunction>();
            services.AddScoped<ICreateNewDiscussionCommentFunction, CreateNewDiscussionCommentFunction>();
            services.AddScoped<ICreateNewDiscussionReplyCommentFunction, CreateNewDiscussionReplyCommentFunction>();
            services.AddScoped<IDeleteDiscussionFunction, DeleteDiscussionFunction>();
            services.AddScoped<IDeleteDiscussionCommentFunction, DeleteDiscussionCommentFunction>();
            services.AddScoped<IDeleteDiscussionReplyCommentFunction, DeleteDiscussionReplyCommentFunction>();
            services.AddScoped<IDiscussionCommentActionFunction, DiscussionCommentActionFunction>();
            services.AddScoped<IDiscussionReplyCommentActionFunction, DiscussionReplyCommentActionFunction>();
            services.AddScoped<IGetDiscussionsFunction, GetDiscussionsFunction>();
            services.AddScoped<IGetDiscussionDetailsFunction, GetDiscussionDetailsFunction>();

            return services;
        }
    }
}
