using learn_programming_services.Database.Entity;

namespace learn_programming_services.Database.Repository
{
    public interface IUsersRepository
    {
        Task<IEnumerable<Users>> getAllUsers();

        Task createNewUser(Users user);

        Task<Users> findLatestUser();

        Task<Users> findUserById(int id);

        Task updateUser(Users user);
    }
}
