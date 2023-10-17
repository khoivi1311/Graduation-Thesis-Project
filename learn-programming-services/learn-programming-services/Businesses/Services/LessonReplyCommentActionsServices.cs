using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class LessonReplyCommentActionsServices : ILessonReplyCommentActionsServices
    {
        private readonly ILessonReplyCommentActionsRepository _lessonReplyCommentActionsRepository;

        public LessonReplyCommentActionsServices(ILessonReplyCommentActionsRepository lessonReplyCommentActionsRepository)
        {
            _lessonReplyCommentActionsRepository = lessonReplyCommentActionsRepository;
        }

        public async Task<IEnumerable<LessonReplyCommentActions>> GetAllLessonReplyCommentActions()
        {
            return await _lessonReplyCommentActionsRepository.getAllLessonReplyCommentActions();
        }

        public async Task UpdateLessonReplyCommentAction(LessonReplyCommentActions lessonReplyCommentAction)
        {
            await _lessonReplyCommentActionsRepository.updateLessonReplyCommentAction(lessonReplyCommentAction);
        }

        public async Task CreateNewLessonReplyCommentAction(LessonReplyCommentActions lessonReplyCommentAction)
        {
            await _lessonReplyCommentActionsRepository.createNewLessonReplyCommentAction(lessonReplyCommentAction);
        }
    }
}
