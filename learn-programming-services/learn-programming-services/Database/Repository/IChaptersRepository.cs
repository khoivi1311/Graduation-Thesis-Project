using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface IChaptersRepository
    {
        Task<IEnumerable<Chapters>> getAllChapters();

        Task createNewChapter(Chapters chapter);

        Task<Chapters> findChapterById(int id);

        Task updateChapter(Chapters chapter);

        Task<IEnumerable<Chapters>> findChapterByCourseId(int courseId);
    }
}
