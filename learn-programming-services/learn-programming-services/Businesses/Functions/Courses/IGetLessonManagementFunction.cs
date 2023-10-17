namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface IGetLessonManagementFunction
    {
        public class Request
        {
            public int chapterId { get; set; }

            public Request(int chapterId)
            {
                this.chapterId = chapterId;
            }
        }

        public class Response
        {
            public List<Lesson> lessons { get; set; }

            public Response(List<Lesson> lessons)
            {
                this.lessons = lessons;
            }

            public Response()
            {
                this.lessons = null;
            }
        }
        
        public class Lesson
        {
            public int lessonId { get; set; }

            public string lessonName { get; set; }

            public int score { get; set; }

            public bool isHidden { get; set; }
        }

        Task<Response> GetLessonManagement(Request request);
    }
}
