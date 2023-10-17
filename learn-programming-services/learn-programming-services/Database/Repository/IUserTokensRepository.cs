using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface IUserTokensRepository
    {
        Task<IEnumerable<UserTokens>> getAllUserTokens();

        Task createNewUserToken(UserTokens userTokens);

        Task updateUserToken(UserTokens userTokens);
    }
}
