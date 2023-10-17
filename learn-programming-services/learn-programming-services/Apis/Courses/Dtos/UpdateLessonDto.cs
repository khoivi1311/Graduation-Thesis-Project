namespace learn_programming_services.Apis.Courses.Dtos
{
    public class UpdateLessonDto
    {
        public int lessonId { get; set; }

        public string lessonName { get; set; }

        public string content { get; set; }

        public int score { get; set; }

        public List<TestCase> testCases { get; set; }

        public List<CodeSample> codeSamples { get; set; }
    }

    public class TestCase
    {
        public int testCaseId { get; set; }

        public string input { get; set; }

        public string expectedOutput { get; set; }

        public bool isHidden { get; set; }
    }

    public class CodeSample
    {
        public int codeSampleId { get; set; }

        public string codeSample { get; set; }

        public int codeLanguageId { get; set; }
    }
}
