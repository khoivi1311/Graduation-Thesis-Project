using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class UserTokensServices : IUserTokensServices
    {
        private readonly IUserTokensRepository _userTokensRepository;

        public UserTokensServices(IUserTokensRepository userTokensRepository)
        {
            _userTokensRepository = userTokensRepository;
        }

        public async Task<IEnumerable<UserTokens>> GetAllUserTokens()
        {
            return await _userTokensRepository.getAllUserTokens();
        }

        public async Task CreateNewUserToken(UserTokens userTokens)
        {
            await _userTokensRepository.createNewUserToken(userTokens);
        }

        public async Task UpdateUserToken(UserTokens userTokens)
        {
            await _userTokensRepository.updateUserToken(userTokens);
        }
    }
}
