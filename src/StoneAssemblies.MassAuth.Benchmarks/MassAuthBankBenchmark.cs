namespace StoneAssemblies.MassAuth.Benchmarks
{
    using System.Net.Http;
    using System.Threading.Tasks;

    using BenchmarkDotNet.Attributes;

    public class MassAuthBankBenchmark
    {
        private readonly HttpClient httpClient;

        public MassAuthBankBenchmark()
        {
            this.httpClient = new HttpClient();
        }

        [Benchmark]
        public async Task InvalidRequestAsync()
        {
            await this.httpClient.GetAsync("http://localhost:6001/api/balance?PrimaryAccountNumber=12345");
        }

        [Benchmark]
        public async Task ValidRequestAsync()
        {
            await this.httpClient.GetAsync("http://localhost:6001/api/balance?PrimaryAccountNumber=123456");
        }
    }
}