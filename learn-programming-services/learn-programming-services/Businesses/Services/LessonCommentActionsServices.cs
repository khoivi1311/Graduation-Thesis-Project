using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class LessonCommentActionsServices : ILessonCommentActionsServices
    {
        private readonly ILessonCommentActionsRepository _lessonCommentActionsRepository;

        public LessonCommentActionsServices(ILessonCommentActionsRepository lessonCommentActionsRepository)
        {
            _lessonCommentActionsRepository = lessonCommentActionsRepository;
        }

        public async Task<IEnumerable<LessonCommentActions>> GetAllLessonCommentActions()
        {
            return await _lessonCommentActionsRepository.getAllLessonCommentActions();
        }

        public async Task UpdateLessonCommentAction(LessonCommentActions lessonCommentAction)
        {
            await _lessonCommentActionsRepository.updateLessonCommentAction(lessonCommentAction);
        }

        public async Task CreateNewLessonCommentAction(LessonCommentActions lessonCommentAction)
        {
            await _lessonCommentActionsRepository.createNewLessonCommentAction(lessonCommentAction);
        }
    }
}
