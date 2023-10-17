namespace learn_programming_services.Businesses.Functions.Contests
{
    public interface IGetContestStatusesFunction
    {
        public class Response
        {
            public List<ContestStatus> contestStatuses { get; set; }

            public Response(List<ContestStatus> contestStatuses) 
            {
                this.contestStatuses = contestStatuses;
            }
        }

        public class ContestStatus
        {
            public int statusId { get; set; }

            public string statusName { get; set; }

            public string statusDescription { get; set; }
        }

        Task<Response> GetContestStatuses();
    }
}
