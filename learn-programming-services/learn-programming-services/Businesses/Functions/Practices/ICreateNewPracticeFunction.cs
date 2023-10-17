using learn_programming_services.Apis.Practices.Dtos;

namespace learn_programming_services.Businesses.Functions.Practices
{
    public interface ICreateNewPracticeFunction
    {
        public class Request
        {
            public CreateNewPracticeDto newPractice { get; set; }

            public Request(CreateNewPracticeDto newPractice)
            {
                this.newPractice = newPractice;
            }
        }

        public class Response
        {
            public bool isSuccessful { get; set; }

            public List<string> errorMessages { get; set; }

            public Response(bool isSuccessful, List<string> errorMessages)
            {
                this.isSuccessful = isSuccessful;
                this.errorMessages = errorMessages;
            }
        }

        Task<Response> CreateNewPractice(Request request);
    }
}
