namespace learn_programming_services.Businesses.Functions.Courses
{
    public interface IGetCourseDetailsFunction
    {
        public class Request
        {
            public int courseId { get; set; }

            public int userId { get; set; }

            public Request(int courseId, int userId)
            {
                this.courseId = courseId;
                this.userId = userId;
            }
        }

        public class Response
        {
            public int courseId { get; set; }

            public string courseName { get; set; }

            public string authorName { get; set; }

            public string description { get; set; }

            public string objective { get; set; }

            public string reward { get; set; }

            public int time { get; set; }

            public string courseTheme { get; set; }

            public int numberOfStudents { get; set; }

            public float voteScore { get; set; }

            public int numberOfVotes { get; set; }

            public int numberOfLessons { get; set; }

            public bool isRegistered { get; set; }

            public bool isCompleted { get; set; }

            public DateTime? completedDate { get; set; }

            public int completedPercent { get; set; }

            public int totalComments { get; set; }

            public List<ChapterData> chapters { get; set; }

            public Response(int courseId, string courseName, string authorName, string description, string objective, string reward, int time, string courseTheme, int numberOfStudents, float voteScore, int numberOfVotes, int numberOfLessons, bool isRegistered, bool isCompleted, DateTime? completedDate, int completedPercent, int totalComments, List<ChapterData> chapters)
            {
                this.courseId = courseId;
                this.courseName = courseName;
                this.authorName = authorName;
                this.description = description;
                this.objective = objective;
                this.reward = reward;
                this.time = time;
                this.courseTheme = courseTheme;
                this.numberOfStudents = numberOfStudents;
                this.voteScore = voteScore;
                this.numberOfVotes = numberOfVotes;
                this.numberOfLessons = numberOfLessons;
                this.isRegistered = isRegistered;
                this.isCompleted = isCompleted;
                this.completedDate = completedDate;
                this.completedPercent = completedPercent;
                this.totalComments = totalComments;
                this.chapters = chapters;
            }

            public Response()
            {
                this.courseId = 0;
                this.courseName = null;
                this.authorName = null;
                this.description = null;
                this.objective = null;
                this.reward = null;
                this.time = 0;
                this.courseTheme = null;
                this.numberOfStudents = 0;
                this.voteScore = 0;
                this.numberOfVotes = 0;
                this.numberOfLessons = 0;
                this.isRegistered = false;
                this.isCompleted = false;
                this.completedDate = null;
                this.completedPercent = 0;
                this.totalComments = 0;
                this.chapters = null;
            }
        }

        public class ChapterData
        {
            public int id { get; set; }

            public string name { get; set; }

            public List<LessonData> lessons { get; set; }
        }

        public class LessonData
        {
            public int id { get; set; }

            public int lessonNumber { get; set; }

            public bool isLearned { get; set; }
        }

        Task<Response> GetCourseDetails(Request request);
    }
}
