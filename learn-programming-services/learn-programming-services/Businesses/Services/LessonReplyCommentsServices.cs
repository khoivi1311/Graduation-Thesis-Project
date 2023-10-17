using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class LessonReplyCommentsServices : ILessonReplyCommentsServices
    {
        private readonly ILessonReplyCommentsRepository _lessonReplyCommentsRepository;

        public LessonReplyCommentsServices(ILessonReplyCommentsRepository lessonReplyCommentsRepository)
        {
            _lessonReplyCommentsRepository = lessonReplyCommentsRepository;
        }

        public async Task<IEnumerable<LessonReplyComments>> GetAllLessonReplyComments()
        {
            return await _lessonReplyCommentsRepository.getAllLessonReplyComments();
        }

        public async Task<LessonReplyComments> FindLessonReplyCommentById(int id)
        {
            return await _lessonReplyCommentsRepository.findLessonReplyCommentById(id);
        }

        public async Task CreateNewLessonReplyComment(LessonReplyComments lessonReplyComment)
        {
            await _lessonReplyCommentsRepository.createNewLessonReplyComment(lessonReplyComment);
        }

        public async Task UpdateLessonReplyComment(LessonReplyComments lessonReplyComment)
        {
            await _lessonReplyCommentsRepository.updateLessonReplyComment(lessonReplyComment);
        }
    }
}
