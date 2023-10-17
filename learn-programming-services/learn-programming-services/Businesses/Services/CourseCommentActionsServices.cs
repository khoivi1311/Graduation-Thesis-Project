using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class CourseCommentActionsServices : ICourseCommentActionsServices
    {
        private readonly ICourseCommentActionsRepository _courseCommentActionsRepository;

        public CourseCommentActionsServices(ICourseCommentActionsRepository courseCommentActionsRepository)
        {
            _courseCommentActionsRepository = courseCommentActionsRepository;
        }

        public async Task CreateNewCourseCommentAction(CourseCommentActions courseCommentAction)
        {
            await _courseCommentActionsRepository.createNewCourseCommentAction(courseCommentAction);
        }

        public async Task UpdateCourseCommentAction(CourseCommentActions courseCommentAction)
        {
            await _courseCommentActionsRepository.updateCourseCommentAction(courseCommentAction);
        }

        public async Task<IEnumerable<CourseCommentActions>> GetAllCourseCommentActions()
        {
            return await _courseCommentActionsRepository.getAllCourseCommentActions();
        }
    }
}
