using learn_programming_services.Businesses.Functions.Contests;

namespace learn_programming_services.Businesses.Services
{
    public interface IContestsServices
    {
        Task<IGetContestsManagementFunction.Response> GetContestsManagement(IGetContestsManagementFunction.Request request);
    }
}
