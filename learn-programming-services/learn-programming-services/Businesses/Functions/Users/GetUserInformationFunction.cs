using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Users.IGetUserInformationFunction;

namespace learn_programming_services.Businesses.Functions.Users
{
    public class GetUserInformationFunction : IGetUserInformationFunction
    {
        private readonly IUsersServices _usersServices;
        private readonly IRolesServices _rolesServices;
        private readonly IUserPermissionsServices _userPermissionsServices;

        public GetUserInformationFunction(IUsersServices usersServices, IRolesServices rolesServices, IUserPermissionsServices userPermissionsServices)
        {
            _usersServices = usersServices;
            _rolesServices = rolesServices;
            _userPermissionsServices = userPermissionsServices;
        }

        public async Task<Response> GetUserInformation(Request request)
        {
            var user = await _usersServices.FindUserById(request.userId);
            if(user != null && user.IsDeleted.Equals(false))
            {
                var role = await _rolesServices.FindRoleById(user.RoleId);
                var userpermissions = await _userPermissionsServices.GetAllUserPermissions();

                DateTime? dateOfBirth = null;
                if (user.DateOfBirth.HasValue)
                {
                    dateOfBirth = user.DateOfBirth.GetValueOrDefault().ToLocalTime();
                }

                return new Response(user.Id, user.FirstName, user.LastName, dateOfBirth, user.PhoneNumber, user.UserName, user.Email, user.Avatar, role.Name, userpermissions.Where(u => u.UserId.Equals(user.Id)).Select(s => s.PermissionId).ToList());
            }
            return new Response();
        }
    }
}
