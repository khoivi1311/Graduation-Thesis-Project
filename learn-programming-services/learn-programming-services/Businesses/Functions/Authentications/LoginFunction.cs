using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Authentications.ILoginFunction;

namespace learn_programming_services.Businesses.Functions.Authentications
{
    public class LoginFunction : ILoginFunction
    {
        private readonly IAuthenticationServices _authenticationServices;

        public LoginFunction(IAuthenticationServices authenticationServices)
        {
            _authenticationServices = authenticationServices;
        }

        public async Task<Response> Login(Request request)
        {
            var response = await _authenticationServices.Login(request);
            return response;
        }
    }
}
