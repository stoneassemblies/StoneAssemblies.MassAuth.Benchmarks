namespace StoneAssemblies.MassAuth.Benchmarks
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using BenchmarkDotNet.Attributes;

    public class MassAuthValidRulesBenchmark
    {
        private readonly HttpClient httpClient;

        public MassAuthValidRulesBenchmark()
        {
            this.httpClient = new HttpClient();
        }

        [Params(
            "ValidTextMessage001",
            "ValidTextMessage005",
            "ValidTextMessage010",
            "ValidTextMessage020",
            "ValidTextMessage050",
            "ValidTextMessage100")]
        public string MessageType { get; set; }

        [Benchmark]
        public async Task TextMessageRequestAsync()
        {
            await this.httpClient.GetAsync($"http://localhost:6004/api/Authorize/{this.MessageType}?Text=12345");
        }
    }

    public class MassAuthValidRulesScaleBenchmark
    {

        [Params(100)]
        public int RulesCount { get; set; }

        [Params(100, 200)]
        public int ParallelRequests { get; set; }


        [Benchmark]
        public async Task TextMessageRequestAsync()
        {
            using HttpClient httpClient = new HttpClient();
            var tasks = new List<Task>();
            var parallelRequests = this.ParallelRequests;
            for (var i = 0; i < parallelRequests; i++)
            {
                var requestUri =
                    $"http://localhost:6004/api/Authorize/ValidTextMessage{this.RulesCount.ToString().PadLeft(3, '0')}?Text=12345";
                var item = httpClient.GetAsync(requestUri);
                tasks.Add(item);
            }

            await Task.WhenAll(tasks.ToArray());
        }
    }
}