using learn_programming_services.Apis.Authentications.Dtos;

namespace learn_programming_services.Businesses.Functions.Authentications
{
    public interface IRefreshTokenFunction
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

            public TokenDto token { get; set; }

            public Response(bool isSuccessful, string errorMessage, TokenDto token)
            {
                this.isSuccessful = isSuccessful;
                this.errorMessage = errorMessage;
                this.token = token;
            }
        }

        Task<Response> RefreshToken(Request request);
    }
}
