using learn_programming_services.Apis.Practices.Dtos;

namespace learn_programming_services.Businesses.Functions.Practices
{
    public interface ISubmitCodePracticeFunction
    {
        public class Request
        {
            public SubmitCodePracticeDto submitCodePractice { get; set; }

            public Request(SubmitCodePracticeDto submitCodePractice)
            {
                this.submitCodePractice = submitCodePractice;
            }
        }

        public class Response
        {
            public string pass { get; set; }

            public string sampleTestCase { get; set; }

            public string hiddenTestCase { get; set; }

            public int score { get; set; }

            public Response(string pass, string sampleTestCase, string hiddenTestCase, int score)
            {
                this.pass = pass;
                this.sampleTestCase = sampleTestCase;
                this.hiddenTestCase = hiddenTestCase;
                this.score = score;
            }
        }

        Task<Response> SubmitCodePractice(Request request);
    }
}
