using learn_programming_services.Apis.Authentications.Dtos;

namespace learn_programming_services.Businesses.Functions.Authentications
{
    public interface IRegisterFunction
    {
        public class Request
        {
            public RegisterDto register { get; set; }

            public Request(RegisterDto register)
            {
                this.register = register;
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

        Task<Response> Register(Request request);
    }
}
