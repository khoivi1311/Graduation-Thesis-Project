using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class UserPermissionsServices : IUserPermissionsServices
    {
        private readonly IUserPermissionsRepository _userPermissionsRepository;

        public UserPermissionsServices(IUserPermissionsRepository userPermissionsRepository)
        {
            _userPermissionsRepository = userPermissionsRepository;
        }

        public async Task CreateNewUserPermissions(UserPermissions userPermissions)
        {
            await _userPermissionsRepository.createNewUserPermissions(userPermissions);
        }

        public async Task<IEnumerable<UserPermissions>> GetAllUserPermissions()
        {
            return await _userPermissionsRepository.getAllUserPermissions();
        }
    }
}
