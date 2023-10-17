using learn_programming_services.Businesses.Functions.Contests;

namespace learn_programming_services.Businesses.Services
{
    public interface IContestStatusesServices
    {
        Task<IGetContestStatusesFunction.Response> GetContestStatuses();
    }
}
