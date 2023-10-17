using learn_programming_services.Businesses.Functions.Courses;
using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface IChaptersServices
    {
        Task<IEnumerable<Chapters>> GetAllChapters();

        Task<ICreateNewChapterFunction.Response> CreateNewChapter(ICreateNewChapterFunction.Request request);

        Task<IGetChapterDetailsFunction.Response> GetChapterDetails(IGetChapterDetailsFunction.Request request);

        Task<IUpdateChapterFunction.Response> UpdateChapter(IUpdateChapterFunction.Request request);

        Task<IDeleteChapterFunction.Response> DeleteChapter(IDeleteChapterFunction.Request request);

        Task<IHiddenChapterFunction.Response> HiddenChapter(IHiddenChapterFunction.Request request);

        Task<Chapters> FindChapterById(int id);

        Task<IGetChaptersManagementFunction.Response> GetChaptersManagement(IGetChaptersManagementFunction.Request request);
    }
}
