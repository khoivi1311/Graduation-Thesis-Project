namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface IHiddenChapterFunction
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
            public bool isSuccessful { get; set; }

            public string errorMessages { get; set; }

            public Response(bool isSuccessful, string errorMessages)
            {
                this.isSuccessful = isSuccessful;
                this.errorMessages = errorMessages;
            }
        }

        Task<Response> HiddenChapter(Request request);
    }
}
