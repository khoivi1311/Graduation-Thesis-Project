using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class CourseCommentsServices : ICourseCommentsServices
    {
        private readonly ICourseCommentsRepository _courseCommentsRepository;

        public CourseCommentsServices(ICourseCommentsRepository courseCommentsRepository)
        {
            _courseCommentsRepository = courseCommentsRepository;
        }

        public async Task CreateNewCourseComment(CourseComments courseComment)
        {
            await _courseCommentsRepository.createNewCourseComment(courseComment);
        }

        public async Task<CourseComments> FindCourseCommentById(int id)
        {
            return await _courseCommentsRepository.findCourseCommentById(id);
        }

        public async Task<IEnumerable<CourseComments>> GetAllCourseComments()
        {
            return await _courseCommentsRepository.getAllCourseComments();
        }

        public async Task UpdateCourseComment(CourseComments courseComment)
        {
            await _courseCommentsRepository.updateCourseComment(courseComment);
        }
    }
}
