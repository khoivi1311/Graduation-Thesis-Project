using learn_programming_services.Apis.Courses.Dtos;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface ISubmitCodeLessonFunction
    {
        public class Request
        {
            public SubmitCodeLessonDto submitCodeLesson { get; set; }

            public Request(SubmitCodeLessonDto submitCodeLesson)
            {
                this.submitCodeLesson = submitCodeLesson;
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

        Task<Response> SubmitCodeLesson(Request request);
    }
}
