using learn_programming_services.Businesses.Functions.Courses;
using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class ChaptersServices : IChaptersServices
    {
        private readonly IChaptersRepository _chaptersRepository;

        public ChaptersServices(IChaptersRepository chaptersRepository)
        {
            _chaptersRepository = chaptersRepository;
        }

        public async Task<IEnumerable<Chapters>> GetAllChapters()
        {
            return await _chaptersRepository.getAllChapters();
        }

        public async Task<ICreateNewChapterFunction.Response> CreateNewChapter(ICreateNewChapterFunction.Request request)
        {
            Chapters newChapter = new Chapters() 
            {
                Name = request.newChapter.chapterName.Trim(),
                IsDeleted = false,
                IsHidden = true,
                CourseId = request.newChapter.courseId,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
            };

            await _chaptersRepository.createNewChapter(newChapter);

            return new ICreateNewChapterFunction.Response(true, null);
        }

        public async Task<IGetChapterDetailsFunction.Response> GetChapterDetails(IGetChapterDetailsFunction.Request request)
        {
            var chapter = await _chaptersRepository.findChapterById(request.id);

            if (chapter != null && chapter.IsDeleted.Equals(false))
            {
                return new IGetChapterDetailsFunction.Response(chapter.Id, chapter.Name);
            }

            return new IGetChapterDetailsFunction.Response();
        }

        public async Task<IUpdateChapterFunction.Response> UpdateChapter(IUpdateChapterFunction.Request request)
        {
            var chapter = await _chaptersRepository.findChapterById(request.chapter.chapterId);

            if (chapter != null && chapter.IsDeleted.Equals(false))
            {
                chapter.Name = request.chapter.chapterName.Trim();
                chapter.UpdateDate = DateTime.UtcNow;

                await _chaptersRepository.updateChapter(chapter);

                return new IUpdateChapterFunction.Response(true, null);
            }

            return new IUpdateChapterFunction.Response(false, "The chapter is not exist");
        }

        public async Task<IDeleteChapterFunction.Response> DeleteChapter(IDeleteChapterFunction.Request request)
        {
            var chapter = await _chaptersRepository.findChapterById(request.id);

            if (chapter != null && chapter.IsDeleted.Equals(false))
            {
                chapter.IsDeleted = true;
                chapter.UpdateDate= DateTime.UtcNow;

                await _chaptersRepository.updateChapter(chapter);

                return new IDeleteChapterFunction.Response(true, null);
            }

            return new IDeleteChapterFunction.Response(false, "The chapter is not exist");
        }

        public async Task<IHiddenChapterFunction.Response> HiddenChapter(IHiddenChapterFunction.Request request)
        {
            var chapter = await _chaptersRepository.findChapterById(request.id);

            if (chapter != null && chapter.IsDeleted.Equals(false))
            {
                if (chapter.IsHidden.Equals(false))
                {
                    chapter.IsHidden = true;
                    chapter.UpdateDate = DateTime.UtcNow;
                }
                else if (chapter.IsHidden.Equals(true))
                {
                    chapter.IsHidden = false;
                    chapter.UpdateDate = DateTime.UtcNow;
                }

                await _chaptersRepository.updateChapter(chapter);

                return new IHiddenChapterFunction.Response(true, null);
            }

            return new IHiddenChapterFunction.Response(false, "The chapter is not exist");
        }

        public async Task<Chapters> FindChapterById(int id)
        {
            return await _chaptersRepository.findChapterById(id);
        }

        public async Task<IGetChaptersManagementFunction.Response> GetChaptersManagement(IGetChaptersManagementFunction.Request request)
        {
            var chapters = await _chaptersRepository.findChapterByCourseId(request.courseId);

            if(chapters != null && chapters.Count() > 0)
            {
                List<IGetChaptersManagementFunction.ChapterData> chaptersList = new List<IGetChaptersManagementFunction.ChapterData>();

                foreach(var chapter in chapters)
                {
                    if (chapter.IsDeleted.Equals(false))
                    {
                        IGetChaptersManagementFunction.ChapterData data = new IGetChaptersManagementFunction.ChapterData()
                        {
                            chapterId = chapter.Id,
                            chapterName = chapter.Name,
                            isHidden = chapter.IsHidden,
                        };

                        chaptersList.Add(data);
                    }
                }

                return new IGetChaptersManagementFunction.Response(chaptersList);
            }

            return new IGetChaptersManagementFunction.Response();
        }
    }
}
