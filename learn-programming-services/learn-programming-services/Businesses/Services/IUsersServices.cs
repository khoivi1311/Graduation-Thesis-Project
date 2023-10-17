using learn_programming_services.Businesses.Functions.Authentications;
using learn_programming_services.Businesses.Functions.Users;
using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface IUsersServices
    {
        Task<IEnumerable<Users>> GetAllUsers();

        Task CreateNewUser(Users user);

        Task<Users> FindLatestUser();

        Task<Users> FindUserById(int id);

        Task<IUpdateUserInformationFunction.Response> UpdateUserInformation(IUpdateUserInformationFunction.Request request);
    }
}
