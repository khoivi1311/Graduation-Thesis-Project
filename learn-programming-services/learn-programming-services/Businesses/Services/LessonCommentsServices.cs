using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class LessonCommentsServices : ILessonCommentsServices
    {
        private readonly ILessonCommentsRepository _lessonCommentsRepository;

        public LessonCommentsServices(ILessonCommentsRepository lessonCommentsRepository)
        {
            _lessonCommentsRepository = lessonCommentsRepository;
        }

        public async Task CreateNewLessonComment(LessonComments lessonComment)
        {
            await _lessonCommentsRepository.createNewLessonComment(lessonComment);
        }

        public async Task UpdateLessonComment(LessonComments lessonComment)
        {
            await _lessonCommentsRepository.updateLessonComment(lessonComment);
        }

        public async Task<LessonComments> FindLessonCommentById(int id)
        {
            return await _lessonCommentsRepository.findLessonCommentById(id);
        }

        public async Task<IEnumerable<LessonComments>> GetAllLessonComments()
        {
            return await _lessonCommentsRepository.getAllLessonComments();
        }
    }
}
