using learn_programming_services.Businesses.Services;
using static learn_programming_services.Businesses.Functions.Courses.IGetCourseLevelsFunction;

namespace learn_programming_services.Businesses.Functions.Courses
{
    public class GetCourseLevelsFunction : IGetCourseLevelsFunction
    {
        private readonly ICourseLevelsServices _courseLevelsServices;

        public GetCourseLevelsFunction(ICourseLevelsServices courseLevelsServices)
        {
            _courseLevelsServices = courseLevelsServices;
        }

        public async Task<Response> GetCourseLevels()
        {
            var courseLevels = await _courseLevelsServices.GetAllCourseLevels();

            List<CourseLevelData> courseLevelData = new List<CourseLevelData>();

            foreach(var courseLevel in courseLevels)
            {
                CourseLevelData data = new CourseLevelData()
                {
                    id = courseLevel.Id,
                    levelName = courseLevel.Name
                };

                courseLevelData.Add(data);
            }

            return new Response(courseLevelData);
        }
    }
}
