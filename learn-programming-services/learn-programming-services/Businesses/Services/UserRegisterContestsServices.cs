using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class UserRegisterContestsServices : IUserRegisterContestsServices
    {
        private readonly IUserRegisterContestsRepository _userRegisterContestsRepository;

        public UserRegisterContestsServices(IUserRegisterContestsRepository userRegisterContestsRepository)
        {
            _userRegisterContestsRepository = userRegisterContestsRepository;
        }
    }
}
