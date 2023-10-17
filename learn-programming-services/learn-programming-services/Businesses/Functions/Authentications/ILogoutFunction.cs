using learn_programming_services.Apis.Authentications.Dtos;

namespace learn_programming_services.Businesses.Functions.Authentications
{
    public interface ILogoutFunction
    {
        public class Request
        {
            public TokenDto token { get; set; }

            public Request(TokenDto token)
            {
                this.token = token;
            }
        }

        public class Response
        {
            public bool isSuccessful { get; set; }

            public string errorMessage { get; set; }

            public Response(bool isSuccessful, string errorMessage)
            {
                this.isSuccessful = isSuccessful;
                this.errorMessage = errorMessage;
            }
        }

        Task<Response> Logout(Request request);
    }
}
