using learn_programming_services.Apis.Practices.Dtos;

namespace learn_programming_services.Businesses.Functions.Practices
{
    public interface IUpdatePracticeFunction
    {
        public class Request
        {
            public UpdatePracticeDto practice { get; set; }

            public Request(UpdatePracticeDto practice)
            {
                this.practice = practice;
            }
        }

        public class Response
        {
            public bool isSuccessful { get; set; }

            public string errorMessages { get; set; }

            public Response(bool isSuccessful, string errorMessages)
            {
                this.isSuccessful = isSuccessful;
                this.errorMessages = errorMessages;
            }
        }

        Task<Response> UpdatePractice(Request request);
    }
}
