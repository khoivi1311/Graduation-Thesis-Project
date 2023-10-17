using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface IRolesServices
    {
        Task<Roles> FindRoleById(int id);
    }
}
