namespace learn_programming_services.Apis.Practices.Dtos
{
    public class UpdatePracticeDto
    {
        public int practiceId {  get; set; }

        public string practiceName { get; set; }

        public string content { get; set; }

        public int score { get; set; }

        public int practiceLevelId { get; set; }

        public List<TestCase> testCases { get; set; }
    }

    public class TestCase
    {
        public int testCaseId { get; set; }

        public string input { get; set; }

        public string expectedOutput { get; set; }

        public bool isHidden { get; set; }
    }
}
