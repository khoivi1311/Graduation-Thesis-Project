using learn_programming_services.Apis.Courses.Dtos;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface IUpdateChapterFunction
    {
        public class Request
        {
            public UpdateChapterDto chapter { get; set; }

            public Request(UpdateChapterDto chapter) 
            {
                this.chapter = chapter;
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

        Task<Response> UpdateChapter(Request request);
    }
}
