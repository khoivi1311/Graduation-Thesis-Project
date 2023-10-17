using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface IUserTokensServices
    {
        Task<IEnumerable<UserTokens>> GetAllUserTokens();

        Task CreateNewUserToken(UserTokens userTokens);

        Task UpdateUserToken(UserTokens userTokens);
    }
}
