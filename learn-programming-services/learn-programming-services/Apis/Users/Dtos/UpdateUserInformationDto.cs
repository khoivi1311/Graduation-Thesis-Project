namespace learn_programming_services.Apis.Users.Dtos
{
    public class UpdateUserInformationDto
    {
        public int id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public DateTime? dateOfBirth { get; set; }

        public string? phoneNumber { get; set; }

        public string email { get; set; }

        public string? avatar { get; set; }
    }
}
