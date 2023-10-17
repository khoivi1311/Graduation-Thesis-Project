using learn_programming_services.Apis.Users.Dtos;

namespace learn_programming_services.Businesses.Functions.Users
{
    public interface IUpdateUserInformationFunction
    {
        public class Request
        {
            public UpdateUserInformationDto userInformation { get; set; }

            public Request(UpdateUserInformationDto userInformation) 
            {
                this.userInformation = userInformation;
            }
        }

        public class Response
        {
            public bool isSuccessful { get; set; }

            public string errorMessages { get; set; }

            public Response(bool isSuccessful, string errorMessages)
            {
                this.isSuccessful = isSuccessful;
                this.errorMessages = errorMessages;
            }
        }

        Task<Response> UpdateUserInformation(Request request);
    }
}
