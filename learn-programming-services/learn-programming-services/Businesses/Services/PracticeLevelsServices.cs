using learn_programming_services.Businesses.Functions.Practices;
using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class PracticeLevelsServices : IPracticeLevelsServices
    {
        private readonly IPracticeLevelsRepository _practiceLevelsRepository;

        public PracticeLevelsServices(IPracticeLevelsRepository practiceLevelsRepository)
        {
            _practiceLevelsRepository = practiceLevelsRepository;
        }

        public async Task<IGetPracticeLevelsFunction.Response> GetPracticeLevels()
        {
            var levels = await _practiceLevelsRepository.getAllPracticeLevels();

            List<IGetPracticeLevelsFunction.PracticeLevel> levelsList = new List<IGetPracticeLevelsFunction.PracticeLevel>();

            if (levels != null && levels.Count() > 0) 
            {
                foreach(var level in levels)
                {
                    IGetPracticeLevelsFunction.PracticeLevel data = new IGetPracticeLevelsFunction.PracticeLevel()
                    {
                        id = level.Id,
                        name = level.Name
                    };

                    levelsList.Add(data);
                }
            }

            return new IGetPracticeLevelsFunction.Response(levelsList);
        }

        public async Task<IEnumerable<PracticeLevels>> GetAllPracticeLevels()
        {
            return await _practiceLevelsRepository.getAllPracticeLevels();
        }
    }
}
