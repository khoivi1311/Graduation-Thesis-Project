using learn_programming_services.Businesses.Functions.Contests;
using learn_programming_services.Database.Repository;
using Microsoft.VisualBasic;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace learn_programming_services.Businesses.Services
{
    public class ContestsServices : IContestsServices
    {
        private readonly IContestsRepository _contestsRepository;
        private readonly IUsersServices _usersServices;

        public ContestsServices(IContestsRepository contestsRepository,
            IUsersServices usersServices)
        {
            _contestsRepository = contestsRepository;
            _usersServices = usersServices;
        }

        public async Task<IGetContestsManagementFunction.Response> GetContestsManagement(IGetContestsManagementFunction.Request request)
        {
            var contests = await _contestsRepository.getAllContests();

            List<IGetContestsManagementFunction.ContestManagement> contestsList = new List<IGetContestsManagementFunction.ContestManagement>();

            contests = contests
                .Where(c => c.AuthorId.Equals(request.userId))
                .Where(c => c.IsDeleted.Equals(false))
                .OrderByDescending(c => c.CreateDate)
                .ToList();

            if (request.keyword != null && request.keyword.Trim() != "")
            {
                contests = contests.Where(c => c.Name.Contains(request.keyword)).ToList();
            }

            if(contests != null && contests.Count() > 0)
            {
                var user = await _usersServices.FindUserById(request.userId);

                foreach(var contest in contests)
                {
                    IGetContestsManagementFunction.ContestManagement data = new IGetContestsManagementFunction.ContestManagement()
                    {
                        contestId = contest.Id,
                        name = contest.Name,
                        description = contest.Description,
                        information = contest.Information,
                        location = contest.Location,
                        statusId = contest.ContestStatusId,
                        authorName = user.UserName,
                        startTime = contest.StartTime.ToLocalTime(),
                        endTime = contest.EndTime.ToLocalTime(),
                        isHidden = contest.IsHidden,
                    };

                    contestsList.Add(data);
                }
            }

            return new IGetContestsManagementFunction.Response(contestsList);
        }
    }
}
