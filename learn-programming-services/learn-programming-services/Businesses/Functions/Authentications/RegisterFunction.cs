using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Authentications.IRegisterFunction;

namespace learn_programming_services.Businesses.Functions.Authentications
{
    public class RegisterFunction : IRegisterFunction
    {
        private readonly IAuthenticationServices _authenticationServices;

        public RegisterFunction(IAuthenticationServices authenticationServices) 
        {
            _authenticationServices = authenticationServices;
        }

        public async Task<Response> Register(Request request)
        {
            var response = await _authenticationServices.Register(request);
            return response;
        }
    }
}
