namespace learn_programming_services.Businesses.Services
{
    public interface IJobeServices
    {
        public class JobeRunData
        {
            public JobeDataInput run_spec { get; set; }

            public JobeRunData(JobeDataInput run_spec)
            {
                this.run_spec = run_spec;
            }
        }

        public class JobeRunResponse
        {
            public string run_id { get; set; }

            public int outcome { get; set; }

            public string cmpinfo { get; set; }

            public string stdout { get; set; }

            public string stderr { get; set; }
        }

        public class JobeDataInput
        {
            public string language_id { get; set; }

            public string sourcecode { get; set; }

            public string input { get; set; }
        }

        Task<JobeRunResponse> JobeRun(JobeDataInput data);
    }
}
