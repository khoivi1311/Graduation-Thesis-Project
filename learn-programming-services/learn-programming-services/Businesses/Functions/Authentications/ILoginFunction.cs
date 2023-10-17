using learn_programming_services.Apis.Authentications.Dtos;

namespace learn_programming_services.Businesses.Functions.Authentications
{
    public interface ILoginFunction
    {
        public class Request
        {
            public LoginDto login { get; set; }

            public Request(LoginDto login)
            {
                this.login = login;
            }
        }

        public class Response
        {
            public bool isSuccessful { get; set; }

            public string errorMessage { get; set; }

            public int userId { get; set; }

            public string userName { get; set; }

            public TokenDto token { get; set; }

            public Response(bool isSuccessful, string errorMessage, int userId, string userName, TokenDto token)
            {
                this.isSuccessful = isSuccessful;
                this.errorMessage = errorMessage;
                this.userId = userId;
                this.userName = userName;
                this.token = token;
            }
        }

        Task<Response> Login(Request request);
    }
}
