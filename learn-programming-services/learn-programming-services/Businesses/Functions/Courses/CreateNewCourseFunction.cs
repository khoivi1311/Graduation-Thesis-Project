using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.ICreateNewCourseFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class CreateNewCourseFunction : ICreateNewCourseFunction
    {
        private readonly ICoursesServices _coursesServices;

        public CreateNewCourseFunction(ICoursesServices coursesServices)
        {
            _coursesServices = coursesServices;
        }

        public async Task<Response> CreateNewCourse(Request request)
        {
            List<string> errors = new List<string>();
            
            if((request.newCourse.courseName != null && request.newCourse.courseName.Trim() != "") && 
                (request.newCourse.description != null && request.newCourse.description.Trim() != "") && 
                (request.newCourse.objective != null && request.newCourse.objective.Trim() != "") &&
                (request.newCourse.reward != null && request.newCourse.reward.Trim() != "") &&
                (request.newCourse.time > 0) &&
                (request.newCourse.courseImage != null && request.newCourse.courseImage.Trim() != "") &&
                (request.newCourse.courseTheme != null && request.newCourse.courseTheme.Trim() != "") &&
                (request.newCourse.courseLevelId > 0) &&
                (request.newCourse.authorId > 0))
            {
                var response = await _coursesServices.CreateNewCourse(request);
                return response;
            }

            errors.Add("The fields are not allowed to be null");
            return new Response(false, errors);
        }
    }
}
