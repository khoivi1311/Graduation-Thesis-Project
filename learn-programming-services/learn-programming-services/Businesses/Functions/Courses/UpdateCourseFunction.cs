using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IUpdateCourseFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class UpdateCourseFunction : IUpdateCourseFunction
    {
        private readonly ICoursesServices _coursesServices;

        public UpdateCourseFunction(ICoursesServices coursesServices)
        {
            _coursesServices = coursesServices;
        }

        public async Task<Response> UpdateCourse(Request request)
        {
            List<string> errors = new List<string>();

            if ((request.course.courseId > 0) &&
                (request.course.courseName != null && request.course.courseName.Trim() != "") &&
                (request.course.description != null && request.course.description.Trim() != "") &&
                (request.course.objective != null && request.course.objective.Trim() != "") &&
                (request.course.reward != null && request.course.reward.Trim() != "") &&
                (request.course.courseImage != null && request.course.courseImage.Trim() != "") &&
                (request.course.courseTheme != null && request.course.courseTheme.Trim() != "") &&
                (request.course.time > 0) &&
                (request.course.courseLevelId > 0))
            {
                var response = await _coursesServices.UpdateCourse(request);
                return response;
            }

            errors.Add("The fields are not allowed to be null");
            return new Response(false, errors);
        }
    }
}
