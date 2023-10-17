namespace learn_programming_services.Apis.Courses.Dtos
{
    public class SubmitCodeLessonDto
    {
        public int lessonId { get; set; }

        public string lessonCode { get; set; }

        public int codeLanguageId { get; set; }

        public int userId { get; set; }
    }
}
