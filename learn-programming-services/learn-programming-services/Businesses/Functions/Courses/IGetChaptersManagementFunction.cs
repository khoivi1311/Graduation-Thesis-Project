namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface IGetChaptersManagementFunction
    {
        public class Request
        {
            public int courseId { get; set; }

            public Request(int courseId)
            {
                this.courseId = courseId;
            }
        }

        public class Response
        {
            public List<ChapterData> chapters { get; set; }

            public Response (List<ChapterData> chapters)
            {
                this.chapters = chapters;
            }

            public Response()
            {
                this.chapters = null;
            }
        }

        public class ChapterData
        {
            public int chapterId { get; set; }

            public string chapterName { get; set; }

            public bool isHidden { get; set; }
        }

        Task<Response> GetChaptersManagement(Request request);
    }
}
