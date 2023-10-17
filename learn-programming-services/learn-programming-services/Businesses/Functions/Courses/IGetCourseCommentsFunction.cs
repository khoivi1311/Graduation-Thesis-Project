namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface IGetCourseCommentsFunction
    {
        public class Request
        {
            public int courseId { get; set; }

            public int userId { get; set; }

            public Request(int courseId, int userId)
            {
                this.courseId = courseId;
                this.userId = userId;
            }
        }

        public class Response
        {
            public List<CourseCommentData> courseComments { get; set; }

            public Response(List<CourseCommentData> courseComments)
            {
                this.courseComments = courseComments;
            }

            public Response()
            {
                this.courseComments = null;
            }
        }

        public class CourseCommentData
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

            public List<CourseReplyCommentData> replyComments { get; set; }
        }

        public class CourseReplyCommentData
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

        Task<Response> GetCourseComments(Request request);
    }
}
