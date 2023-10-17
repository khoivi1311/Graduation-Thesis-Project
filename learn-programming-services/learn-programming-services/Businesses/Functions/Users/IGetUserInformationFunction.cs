namespace learn_programming_services.Businesses.Functions.Users
{
    public interface IGetUserInformationFunction
    {
        public class Request
        {
            public int userId { get; set; }

            public Request(int userId)
            {
                this.userId = userId;
            }
        }

        public class Response
        {
            public int id { get; set; }

            public string firstName { get; set; }

            public string lastName { get; set; }

            public DateTime? dateOfBirth { get; set; }

            public string phoneNumber { get; set; }

            public string userName { get; set; }

            public string email { get; set; }

            public string avatar { get; set; }

            public string role { get; set; }

            public List<int> permissions { get; set; }

            public Response(int id, string firstName, string lastName, DateTime? dateOfBirth, string phoneNumber, string userName, string email, string avatar, string role, List<int> permissions)
            {
                this.id = id;
                this.firstName = firstName;
                this.lastName = lastName;
                this.dateOfBirth = dateOfBirth;
                this.phoneNumber = phoneNumber;
                this.userName = userName;
                this.email = email;
                this.avatar = avatar;
                this.role = role;
                this.permissions = permissions;
            }

            public Response()
            {
                this.id = 0;
                this.firstName = null;
                this.lastName = null;
                this.dateOfBirth = null;
                this.phoneNumber = null;
                this.userName = null;
                this.email = null;
                this.avatar = null;
                this.role = null;
                this.permissions = null;
            }
        }

        Task<Response> GetUserInformation(Request request);
    }
}
