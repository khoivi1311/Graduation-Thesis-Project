using learn_programming_services.Businesses.Functions.Courses;
using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface ICoursesServices
    {
        Task<IEnumerable<Courses>> GetAllCourses();

        Task<IEnumerable<IGetCoursesFunction.CoursesList>> GetCourses(IGetCoursesFunction.Request request);

        Task<IGetCourseDetailsFunction.Response> GetCourseDetails(IGetCourseDetailsFunction.Request request);

        Task<ICourseRegisterFunction.Response> CourseRegister(ICourseRegisterFunction.Request request);

        Task<ICourseCommentFunction.Response> CourseComment(ICourseCommentFunction.Request request);

        Task<ICourseReplyCommentFunction.Response> CourseReplyComment(ICourseReplyCommentFunction.Request request);

        Task<IGetCourseCommentsFunction.Response> GetCourseComments(IGetCourseCommentsFunction.Request request);

        Task<ICourseCommentActionFunction.Response> CourseCommentAction(ICourseCommentActionFunction.Request request);

        Task<ICourseReplyCommentActionFunction.Response> CourseReplyCommentAction(ICourseReplyCommentActionFunction.Request request);

        Task<ICreateNewCourseFunction.Response> CreateNewCourse(ICreateNewCourseFunction.Request request);

        Task<IEnumerable<IGetCoursesManagementFunction.CoursesManagementList>> GetCoursesManagement(IGetCoursesManagementFunction.Request request);

        Task<IDeleteCourseFunction.Response> DeleteCourse(IDeleteCourseFunction.Request request);

        Task<IGetCourseDetailsManagementFunction.Response> GetCourseDetailsManagement(IGetCourseDetailsManagementFunction.Request request);

        Task<IUpdateCourseFunction.Response> UpdateCourse(IUpdateCourseFunction.Request request);

        Task<IHiddenCourseFunction.Response> HiddenCourse(IHiddenCourseFunction.Request request);

        Task<IDeleteCourseCommentFunction.Response> DeleteCourseComment(IDeleteCourseCommentFunction.Request request);

        Task<IDeleteCourseReplyCommentFunction.Response> DeleteCourseReplyComment(IDeleteCourseReplyCommentFunction.Request request);
    }
}
