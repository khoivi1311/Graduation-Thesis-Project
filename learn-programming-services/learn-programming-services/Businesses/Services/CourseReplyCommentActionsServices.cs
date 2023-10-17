using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class CourseReplyCommentActionsServices : ICourseReplyCommentActionsServices
    {
        private readonly ICourseReplyCommentActionsRepository _courseReplyCommentActionsRepository;

        public CourseReplyCommentActionsServices(ICourseReplyCommentActionsRepository courseReplyCommentActionsRepository)
        {
            _courseReplyCommentActionsRepository = courseReplyCommentActionsRepository;
        }

        public async Task CreateNewCourseReplyCommentAction(CourseReplyCommentActions courseReplyCommentAction)
        {
            await _courseReplyCommentActionsRepository.createNewCourseReplyCommentAction(courseReplyCommentAction);
        }

        public async Task UpdateCourseReplyCommentAction(CourseReplyCommentActions courseReplyCommentActions)
        {
            await _courseReplyCommentActionsRepository.updateCourseReplyCommentAction(courseReplyCommentActions);
        }

        public async Task<IEnumerable<CourseReplyCommentActions>> GetAllCourseReplyCommentActions()
        {
            return await _courseReplyCommentActionsRepository.getAllCourseReplyCommentActions();
        }
    }
}
