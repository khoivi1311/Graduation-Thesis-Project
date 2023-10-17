namespace learn_programming_services.Apis.Courses.Dtos
{
    public class CreateNewLessonDto
    {
        public string lessonName { get; set; }

        public string content { get; set; }

        public int score { get; set; }

        public int chapterId { get; set; }

        public int authorId { get; set; }

        public List<TestCaseData> testCases { get; set; }

        public List<CodeSampleData> codeSamples { get; set; }
    }

    public class TestCaseData
    {
        public string input { get; set; }

        public string expectedOutput { get; set; }

        public bool isHidden { get; set; }
    }

    public class CodeSampleData
    {
        public string codeSample { get; set; }

        public int codeLanguageId { get; set; }
    }
}
