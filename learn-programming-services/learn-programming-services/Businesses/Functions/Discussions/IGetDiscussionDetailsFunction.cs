namespace learn_programming_services.Businesses.Functions.Discussions
{
    public interface IGetDiscussionDetailsFunction
    {
        public class Request
        {
            public int discussionId {  get; set; }

            public int userId { get; set; }

            public Request(int discussionId, int userId)
            {
                this.discussionId = discussionId;
                this.userId = userId;
            }
        }

        public class Response
        {
            public int discussionId { get; set; }

            public string discussionName { get; set; }

            public string discussionContent { get; set; }

            public int totalComments { get; set; }

            public int authorId { get; set; }

            public string authorName { get; set; }

            public DateTime discussionDate { get; set; }

            public List<Comment> comments { get; set; }

            public Response(int discussionId, string discussionName, string discussionContent, int totalComments, int authorId, string authorName, DateTime discussionDate, List<Comment> comments)
            {
                this.discussionId = discussionId;
                this.discussionName = discussionName;
                this.discussionContent = discussionContent;
                this.totalComments = totalComments;
                this.authorId = authorId;
                this.authorName = authorName;
                this.discussionDate = discussionDate;
                this.comments = comments;
            }

            public Response() 
            {
                this.discussionId = 0;
                this.discussionName = null;
                this.discussionContent = null;
                this.totalComments = 0;
                this.authorId = 0;
                this.authorName = null;
                this.discussionDate = DateTime.MinValue;
                this.comments = null;
            }
        }

        public class Comment
        {
            public int commentId { get; set; }

            public string content { get; set; }

            public int authorId { get; set; }

            public string authorName { get; set; }

            public int numberOfLike { get; set; }

            public bool isLiked { get; set; }

            public int numberOfDislike { get; set; }

            public bool isDisliked { get; set; }

            public DateTime commentDate { get; set; }

            public List<ReplyComment> replyComments { get; set; }
        }

        public class ReplyComment
        {
            public int commentId { get; set; }

            public string content { get; set; }

            public int authorId { get; set; }

            public string authorName { get; set; }

            public int numberOfLike { get; set; }

            public bool isLiked { get; set; }

            public int numberOfDislike { get; set; }

            public bool isDisliked { get; set; }

            public DateTime commentDate { get; set; }
        }

        Task<Response> GetDiscussionDetails(Request request);
    }
}
