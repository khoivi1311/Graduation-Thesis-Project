namespace learn_programming_services.Apis.Practices.Dtos
{
    public class SubmitCodePracticeDto
    {
        public int practiceId { get; set; }

        public string practiceCode { get; set; }

        public int codeLanguageId { get; set; }

        public int userId { get; set; }
    }
}
