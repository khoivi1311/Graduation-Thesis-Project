namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface IGetCourseLevelsFunction
    {
        public class Response
        {
            public List<CourseLevelData> courseLevels { get; set; }

            public Response(List<CourseLevelData> courseLevels) 
            {
                this.courseLevels = courseLevels;
            }
        }

        public class CourseLevelData
        {
            public int id { get; set; }

            public string levelName { get; set; }
        }

        Task<Response> GetCourseLevels();
    }
}
