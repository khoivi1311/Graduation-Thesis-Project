namespace learn_programming_services.Apis.Courses.Dtos
{
    public class CourseCommentDto
    {
        public int courseId { get; set; }

        public int userId { get; set; }

        public string content { get; set; }
    }
}
