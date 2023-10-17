using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Authentications.IRefreshTokenFunction;

namespace learn_programming_services.Businesses.Functions.Authentications
{
    public class RefreshTokenFunction : IRefreshTokenFunction
    {
        private readonly IAuthenticationServices _authenticationServices;

        public RefreshTokenFunction(IAuthenticationServices authenticationServices)
        {
            _authenticationServices = authenticationServices;
        }

        public async Task<Response> RefreshToken(Request request)
        {
            var response = await _authenticationServices.RefreshToken(request);
            return response;
        }
    }
}
