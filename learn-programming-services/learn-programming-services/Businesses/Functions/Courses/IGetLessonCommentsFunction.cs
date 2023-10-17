namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface IGetLessonCommentsFunction
    {
        public class Request
        {
            public int lessonId { get; set; }

            public int userId { get; set; }

            public Request(int lessonId, int userId)
            {
                this.lessonId = lessonId;
                this.userId = userId;
            }
        }

        public class Response
        {
            public List<LessonCommentData> lessonComments { get; set; }

            public Response(List<LessonCommentData> lessonComments)
            {
                this.lessonComments = lessonComments;
            }

            public Response()
            {
                this.lessonComments = null;
            }
        }

        public class LessonCommentData
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

            public List<LessonReplyCommentData> replyComments { get; set; }
        }

        public class LessonReplyCommentData
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

        Task<Response> GetLessonComments(Request request);
    }
}
