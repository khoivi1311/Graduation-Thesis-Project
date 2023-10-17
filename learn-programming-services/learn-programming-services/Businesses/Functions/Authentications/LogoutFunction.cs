using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Authentications.ILogoutFunction;

namespace learn_programming_services.Businesses.Functions.Authentications
{
    public class LogoutFunction : ILogoutFunction
    {
        private readonly IAuthenticationServices _authenticationServices;

        public LogoutFunction(IAuthenticationServices authenticationServices)
        {
            _authenticationServices = authenticationServices;
        }

        public async Task<Response> Logout(Request request)
        {
            var response = await _authenticationServices.Logout(request);
            return response;
        }
    }
}
