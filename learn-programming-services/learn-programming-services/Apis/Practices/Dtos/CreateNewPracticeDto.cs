namespace learn_programming_services.Apis.Practices.Dtos
{
    public class CreateNewPracticeDto
    {
        public string practiceName { get; set; }
        
        public string content { get; set; }

        public int score { get; set; }

        public int practiceLevelId { get; set; }

        public int authorId { get; set; }

        public List<TestCaseData> testCases { get; set; }
    }

    public class TestCaseData
    {
        public string input { get; set; }

        public string expectedOutput { get; set; }

        public bool isHidden { get; set; }
    }
}
