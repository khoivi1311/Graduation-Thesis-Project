using learn_programming_services.Apis.Courses.Dtos;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface ICreateNewChapterFunction
    {
        public class Request
        {
            public CreateNewChapterDto newChapter { get; set; }

            public Request(CreateNewChapterDto newChapter)
            {
                this.newChapter = newChapter;
            }
        }

        public class Response
        {
            public bool isSuccessful { get; set; }

            public string errorMessages { get; set; }

            public Response(bool isSuccessful, string errorMessages)
            {
                this.isSuccessful = isSuccessful;
                this.errorMessages = errorMessages;
            }
        }

        Task<Response> CreateNewChapter(Request request);
    }
}
