using learn_programming_services.Businesses.Functions.Authentications;

namespace learn_programming_services.Businesses.Services
{
    public interface IAuthenticationServices
    {
        Task<IRegisterFunction.Response> Register(IRegisterFunction.Request request);

        Task<ILoginFunction.Response> Login(ILoginFunction.Request request);

        Task<IRefreshTokenFunction.Response> RefreshToken(IRefreshTokenFunction.Request request);

        Task<ILogoutFunction.Response> Logout(ILogoutFunction.Request request);
    }
}
