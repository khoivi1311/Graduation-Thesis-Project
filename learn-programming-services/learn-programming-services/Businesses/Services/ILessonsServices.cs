using learn_programming_services.Businesses.Functions.Courses;
using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface ILessonsServices
    {
        Task<IEnumerable<Lessons>> GetAllLessons();

        Task<ICreateNewLessonFunction.Response> CreateNewLesson(ICreateNewLessonFunction.Request request);

        Task<IGetLessonManagementDetailsFunction.Response> GetLessonManagementDetails(IGetLessonManagementDetailsFunction.Request request);

        Task<IGetLessonDetailsFunction.Response> GetLessonDetails(IGetLessonDetailsFunction.Request request);

        Task<IUpdateLessonFunction.Response> UpdateLesson(IUpdateLessonFunction.Request request);

        Task<IDeleteLessonFunction.Response> DeleteLesson(IDeleteLessonFunction.Request request);

        Task<IHiddenLessonFunction.Response> HiddenLesson(IHiddenLessonFunction.Request request);

        Task<IGetLessonManagementFunction.Response> GetLessonManagement(IGetLessonManagementFunction.Request request);

        Task<IRunCodeLessonFunction.Response> RunCodeLesson(IRunCodeLessonFunction.Request request);

        Task<ISubmitCodeLessonFunction.Response> SubmitCodeLesson(ISubmitCodeLessonFunction.Request request);

        Task<ILessonCommentFunction.Response> LessonComment(ILessonCommentFunction.Request request);

        Task<ILessonReplyCommentFunction.Response> LessonReplyComment(ILessonReplyCommentFunction.Request request);

        Task<IGetLessonCommentsFunction.Response> GetLessonComments(IGetLessonCommentsFunction.Request request);

        Task<ILessonCommentActionFunction.Response> LessonCommentAction(ILessonCommentActionFunction.Request request);

        Task<ILessonReplyCommentActionFunction.Response> LessonReplyCommentAction(ILessonReplyCommentActionFunction.Request request);

        Task<IDeleteLessonCommentFunction.Response> DeleteLessonComment(IDeleteLessonCommentFunction.Request request);

        Task<IDeleteLessonReplyCommentFunction.Response> DeleteLessonReplyComment(IDeleteLessonReplyCommentFunction.Request request);
    }
}
