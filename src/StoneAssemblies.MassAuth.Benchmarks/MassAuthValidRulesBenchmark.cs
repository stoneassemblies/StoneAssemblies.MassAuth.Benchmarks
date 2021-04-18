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
        [Params(
            "ValidTextMessage001",
            "ValidTextMessage005",
            "ValidTextMessage010",
            "ValidTextMessage020",
            "ValidTextMessage050",
            "ValidTextMessage100")]
        public string MessageType { get; set; }

        [Params(1, 3, 5, 10)]
        public int Paralellism { get; set; }

        [Benchmark]
        public async Task TextMessageRequestAsync()
        {
            var tasks = new List<Task>();
            for (var i = 0; i < this.Paralellism; i++)
            {
                var httpClient = new HttpClient();
                var item = httpClient.GetAsync($"http://localhost:6004/api/Authorize/{this.MessageType}?Text=12345");
                tasks.Add(item);
            }

            await Task.WhenAll(tasks.ToArray());
        }
    }
}