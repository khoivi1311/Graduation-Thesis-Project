using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface IRolesRepository
    {
        Task<Roles> findRoleById(int id);
    }
}
