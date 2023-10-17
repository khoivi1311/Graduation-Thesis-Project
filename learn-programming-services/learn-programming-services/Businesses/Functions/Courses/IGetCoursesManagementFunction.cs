namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface IGetCoursesManagementFunction
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
            public List<CoursesManagementList> coursesLists { get; set; }

            public Response(List<CoursesManagementList> coursesLists)
            {
                this.coursesLists = coursesLists;
            }
        }

        public class CoursesManagementList
        {
            public int courseLevelId { get; set; }

            public string courseLevelName { get; set; }

            public List<CourseManagementData> courses { get; set; }
        }

        public class CourseManagementData
        {
            public int id { get; set; }

            public string courseName { get; set; }

            public string authorName { get; set; }

            public string description { get; set; }

            public string image { get; set; }

            public string theme { get; set; }

            public float voteScore { get; set; }

            public bool isHidden { get; set; }
        }

        Task<Response> GetCoursesManagement(Request request);
    }
}
