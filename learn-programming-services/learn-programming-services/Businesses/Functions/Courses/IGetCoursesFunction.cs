namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface IGetCoursesFunction
    {
        public class Request
        {
            public int userId { get; set; }

            public string? keyword { get; set; }

            public Request(int userId, string? keyword)
            {
                this.userId = userId;
                this.keyword = keyword;
            }
        }

        public class Response
        {
            public List<CoursesList>  coursesLists { get; set; }

            public Response(List<CoursesList> coursesLists)
            {
                this.coursesLists = coursesLists;
            }
        }

        public class CoursesList
        {
            public int courseLevelId { get; set; }

            public string courseLevelName { get; set; }

            public List<CourseData> courses { get; set; }
        }

        public class CourseData
        {
            public int id { get; set; }

            public string courseName { get; set; }

            public string authorName { get; set; }

            public string description { get; set; }

            public string image { get; set; }

            public bool isRegistered { get; set; }

            public int completedPercent { get; set; }

            public float voteScore { get; set; }
        }

        Task<Response> GetCourses(Request request);
    }
}
