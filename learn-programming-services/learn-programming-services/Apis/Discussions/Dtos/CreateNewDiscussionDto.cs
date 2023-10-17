namespace learn_programming_services.Apis.Discussions.Dtos
{
    public class CreateNewDiscussionDto
    {
        public int userId { get; set; }

        public string discussionName { get; set; }

        public string description { get; set; }

        public string content { get; set; }

        public string image { get; set; }
    }
}
