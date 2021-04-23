wnamespace StoneAssemblies.MassAuth.Benchmarks
{
    using System.Net.Http;
    using System.Threading.Tasks;

    using BenchmarkDotNet.Attributes;

    public class MassAuthRandomRulesBenchmark
    {
        private readonly HttpClient httpClient;

        public MassAuthRandomRulesBenchmark()
        {
            this.httpClient = new HttpClient();
        }

        [Params("TextMessage001", "TextMessage005", "TextMessage010")]
        public string MessageType { get; set; }

        [Benchmark]
        public async Task TextMessageRequestAsync()
        {
            await this.httpClient.GetAsync($"http://localhost:6004/api/Authorize/{this.MessageType}?Text=12345");
        }
    }
}