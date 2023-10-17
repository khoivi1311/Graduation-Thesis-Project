using learn_programming_services.Businesses.Functions.Contests;
using learn_programming_services.Database.Repository;

namespace learn_programming_services.Businesses.Services
{
    public class ContestStatusesServices : IContestStatusesServices
    {
        private readonly IContestStatusesRepository _contestStatusesRepository;

        public ContestStatusesServices(IContestStatusesRepository contestStatusesRepository)
        {
            _contestStatusesRepository = contestStatusesRepository;
        }

        public async Task<IGetContestStatusesFunction.Response> GetContestStatuses()
        {
            var statuses = await _contestStatusesRepository.getAllContestStatuses();

            List<IGetContestStatusesFunction.ContestStatus> statusesList = new List<IGetContestStatusesFunction.ContestStatus>();

            if(statuses != null && statuses.Count() > 0) 
            {
                foreach(var status in statuses)
                {
                    IGetContestStatusesFunction.ContestStatus data = new IGetContestStatusesFunction.ContestStatus()
                    {
                        statusId = status.Id,
                        statusName = status.Name,
                        statusDescription = status.Description,
                    };

                    statusesList.Add(data);
                }
            }

            return new IGetContestStatusesFunction.Response(statusesList);
        }
    }
}
