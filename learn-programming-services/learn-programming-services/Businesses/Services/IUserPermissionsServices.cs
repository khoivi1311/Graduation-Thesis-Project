using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface IUserPermissionsServices
    {
        Task CreateNewUserPermissions(UserPermissions userPermissions);

        Task<IEnumerable<UserPermissions>> GetAllUserPermissions();
    }
}
