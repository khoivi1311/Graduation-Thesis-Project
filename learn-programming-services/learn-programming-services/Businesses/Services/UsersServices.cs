using learn_programming_services.Businesses.Functions.Users;
using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly IUsersRepository _userRepository;

        public UsersServices(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            return await _userRepository.getAllUsers();
        }

        public async Task CreateNewUser(Users user)
        {
            await _userRepository.createNewUser(user);
        }

        public async Task<Users> FindLatestUser()
        {
            return await _userRepository.findLatestUser();
        }

        public async Task<Users> FindUserById(int id)
        {
            return await _userRepository.findUserById(id);
        }

        public async Task<IUpdateUserInformationFunction.Response> UpdateUserInformation(IUpdateUserInformationFunction.Request request)
        {
            var users = await _userRepository.getAllUsers();

            foreach(var user in users)
            {
                if (user.Email.ToLower().Equals(request.userInformation.email.ToLower().Trim()) && !user.Id.Equals(request.userInformation.id))
                {
                    return new IUpdateUserInformationFunction.Response(false, "Email already exists");
                }
            }

            var userInfo = users
                .Where(u => u.Id.Equals(request.userInformation.id))
                .Where(u => u.IsDeleted.Equals(false))
                .SingleOrDefault();

            if(userInfo != null)
            {
                userInfo.FirstName = request.userInformation.firstName.Trim();
                userInfo.LastName = request.userInformation.lastName.Trim();
                userInfo.Email = request.userInformation.email.Trim();
                userInfo.UpdateDate = DateTime.UtcNow;

                if (request.userInformation.dateOfBirth != null)
                {
                    userInfo.DateOfBirth = request.userInformation.dateOfBirth;
                }

                if (request.userInformation.phoneNumber != null && request.userInformation.phoneNumber.Trim() != "")
                {
                    userInfo.PhoneNumber = request.userInformation.phoneNumber.Trim();
                }

                if (request.userInformation.avatar != null && request.userInformation.avatar.Trim() != "")
                {
                    userInfo.Avatar = request.userInformation.avatar.Trim();
                }

                await _userRepository.updateUser(userInfo);

                return new IUpdateUserInformationFunction.Response(true, null);
            }

            return new IUpdateUserInformationFunction.Response(false, "The user is not exist");
        }
    }
}
