using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class RolesServices : IRolesServices
    {
        private readonly IRolesRepository _rolesRepository;

        public RolesServices(IRolesRepository rolesRepository) 
        {
            _rolesRepository = rolesRepository;
        }

        public async Task<Roles> FindRoleById(int id)
        {
            return await _rolesRepository.findRoleById(id); 
        }
    }
}
