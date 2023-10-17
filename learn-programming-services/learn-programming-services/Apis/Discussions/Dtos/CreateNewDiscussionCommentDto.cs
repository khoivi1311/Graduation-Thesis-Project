namespace learn_programming_services.Apis.Discussions.Dtos
{
    public class CreateNewDiscussionCommentDto
    {
        public int userId { get; set; }

        public int discussionId{ get; set; }

        public string content { get; set; }
    }
}
