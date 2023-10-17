using System.ComponentModel.DataAnnotations;

namespace learn_programming_services.Apis.Authentications.Dtos
{
    public class RegisterDto
    {
        public string firstName {  get; set; }

        public string lastName { get; set; }

        public string userName {  get; set; }

        [EmailAddress]
        public string email { get; set; }

        public string password { get; set; }

        public string rePassword { get; set; }
    }
}
