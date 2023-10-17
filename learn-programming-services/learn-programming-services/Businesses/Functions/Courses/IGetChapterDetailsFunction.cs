namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface IGetChapterDetailsFunction
    {
        public class Request
        {
            public int id { get; set; }

            public Request(int id)
            {
                this.id = id;
            }
        }

        public class Response
        {
            public int chapterId { get; set; }

            public string chapterName { get; set; }

            public Response(int chapterId, string chapterName)
            {
                this.chapterId = chapterId;
                this.chapterName = chapterName;
            }

            public Response()
            {
                this.chapterId = 0;
                this.chapterName = null;
            }
        }

        Task<Response> GetChapterDetails(Request request);
    }
}
