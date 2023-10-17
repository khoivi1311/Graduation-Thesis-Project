namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface IGetCourseDetailsManagementFunction
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
            public int courseId { get; set; }

            public string courseName { get; set; }

            public string description { get; set; }

            public string objective { get; set; }

            public string reward { get; set; }

            public int time { get; set; }

            public string image { get; set; }

            public string theme { get; set; }

            public int courseLevel { get; set; }

            public int author { get; set; }

            public Response(int courseId, string courseName, string description, string objective, string reward, int time, string image, string theme, int courseLevel, int author)
            {
                this.courseId = courseId;
                this.courseName = courseName;
                this.description = description;
                this.objective = objective;
                this.reward = reward;
                this.time = time;
                this.image = image;
                this.theme = theme;
                this.courseLevel = courseLevel;
                this.author = author;
            }

            public Response() 
            {
                this.courseId = 0;
                this.courseName = null;
                this.description = null;
                this.objective = null;
                this.reward = null;
                this.time = 0;
                this.image = null;
                this.theme = null;
                this.courseLevel = 0;
                this.author = 0;
            }

        }

        Task<Response> GetCourseDetailsManagement(Request request);
    }
}
