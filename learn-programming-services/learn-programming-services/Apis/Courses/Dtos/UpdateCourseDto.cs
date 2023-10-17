namespace learn_programming_services.Apis.Courses.Dtos
{
    public class UpdateCourseDto
    {
        public int courseId { get; set; }

        public string courseName { get; set; }

        public string description { get; set; }

        public string objective { get; set; }

        public string reward { get; set; }

        public int time { get; set; }

        public string courseImage { get; set; }

        public string courseTheme { get; set; }

        public int courseLevelId { get; set; }
    }
}
