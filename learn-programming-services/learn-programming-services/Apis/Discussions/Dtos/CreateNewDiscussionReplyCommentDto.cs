namespace learn_programming_services.Apis.Discussions.Dtos
{
    public class CreateNewDiscussionReplyCommentDto
    {
        public int userId { get; set; }

        public int discussionCommentId { get; set; }

        public string content { get; set; }
    }
}
