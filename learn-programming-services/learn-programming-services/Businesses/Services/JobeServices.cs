using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using static learn_programming_services.Businesses.Services.IJobeServices;

namespace learn_programming_services.Businesses.Services
{
    public class JobeServices : IJobeServices
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public JobeServices(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<JobeRunResponse> JobeRun(JobeDataInput data)
        {
            HttpClient client = _httpClientFactory.CreateClient("JobeServer");

            var runData = new JobeRunData(data);

            var runDataJson = JsonConvert.SerializeObject(runData);

            var response = await client.PostAsync("runs", new StringContent(runDataJson, Encoding.UTF8, "application/json"));

            var responseData = JsonConvert.DeserializeObject<JobeRunResponse>(await response.Content.ReadAsStringAsync());

            return responseData;
        }
    }
}
