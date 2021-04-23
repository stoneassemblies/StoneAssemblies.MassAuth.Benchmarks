namespace StoneAssemblies.MassAuth.Benchmarks
{
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
}