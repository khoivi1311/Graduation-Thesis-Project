using learn_programming_services.Businesses.Functions.Practices;
using learn_programming_services.Database.Entity;

namespace learn_programming_services.Businesses.Services
{
    public interface IPracticeLevelsServices
    {
        Task<IGetPracticeLevelsFunction.Response> GetPracticeLevels();

        Task<IEnumerable<PracticeLevels>> GetAllPracticeLevels();
    }
}
