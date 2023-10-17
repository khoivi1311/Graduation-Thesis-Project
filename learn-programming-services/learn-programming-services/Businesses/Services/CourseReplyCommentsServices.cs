using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class CourseReplyCommentsServices : ICourseReplyCommentsServices
    {
        private readonly ICourseReplyCommentsRepository _courseReplyCommentsRepository;

        public CourseReplyCommentsServices(ICourseReplyCommentsRepository courseReplyCommentsRepository)
        {
            _courseReplyCommentsRepository = courseReplyCommentsRepository;
        }

        public async Task CreateNewCourseReplyComment(CourseReplyComments courseReplyComment)
        {
            await _courseReplyCommentsRepository.createNewCourseReplyComment(courseReplyComment);
        }

        public async Task<IEnumerable<CourseReplyComments>> GetAllCourseReplyComments()
        {
            return await _courseReplyCommentsRepository.getAllCourseReplyComments();
        }

        public async Task<CourseReplyComments> FindCourseReplyCommentById(int id)
        {
            return await _courseReplyCommentsRepository.findCourseReplyCommentById(id);
        }

        public async Task UpdateCourseReplyComment(CourseReplyComments courseReplyComment)
        {
            await _courseReplyCommentsRepository.updateCourseReplyComment(courseReplyComment);
        }
    }
}
