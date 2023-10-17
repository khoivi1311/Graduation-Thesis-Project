using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Users.IUpdateUserInformationFunction;

namespace learn_programming_services.Businesses.Functions.Users
{
    public class UpdateUserInformationFunction : IUpdateUserInformationFunction
    {
        private readonly IUsersServices _usersServices;

        public UpdateUserInformationFunction(IUsersServices usersServices)
        {
            _usersServices = usersServices;
        }

        public async Task<Response> UpdateUserInformation(Request request)
        {
            if(request.userInformation.id > 0 &&
              (request.userInformation.firstName != null && request.userInformation.firstName.Trim() != "") &&
              (request.userInformation.lastName != null && request.userInformation.lastName.Trim() != "") &&
              (request.userInformation.email != null && request.userInformation.email.Trim() != ""))
            {
                var response = await _usersServices.UpdateUserInformation(request);
                return response;
            }

            return new Response(false, "The fields are not allowed to be null");
        }
    }
}
