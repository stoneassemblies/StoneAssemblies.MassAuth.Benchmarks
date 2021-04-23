namespace StoneAssemblies.MassAuth.Benchmarks
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using BenchmarkDotNet.Attributes;

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