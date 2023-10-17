namespace learn_programming_services.Businesses.Functions.Practices
{
    public interface IGetPracticeLevelsFunction
    {
        public class Response
        {
            public List<PracticeLevel> levels { get; set; }

            public Response(List<PracticeLevel> levels)
            {
                this.levels = levels.ToList();
            }
        }

        public class PracticeLevel
        {
            public int id { get; set; }

            public string name { get; set; }
        }

        Task<Response> GetPracticeLevels();
    }
}
