using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface IUserPermissionsRepository
    {
        Task createNewUserPermissions(UserPermissions userPermissions);

        Task<IEnumerable<UserPermissions>> getAllUserPermissions();
    }
}
