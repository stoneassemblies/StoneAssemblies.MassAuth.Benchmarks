namespace StoneAssemblies.MassAuth.Benchmarks;

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using BenchmarkDotNet.Attributes;

public class MassAuthValidRulesScale5x100x100Benchmark
{
    private readonly HttpClient httpClient = new HttpClient();

    [Params(100)]
    public int ParallelRequests { get; set; }

    [Params(100)]
    public int RulesCount { get; set; }

    [Benchmark]
    public async Task TextMessageRequestAsync()
    {
        var tasks = new List<Task>();
        var parallelRequests = this.ParallelRequests;
        for (var i = 0; i < parallelRequests; i++)
        {
            var requestUri =
                $"http://localhost:6004/api/Authorize/ValidTextMessage{this.RulesCount.ToString().PadLeft(3, '0')}?Text=12345";
            var item = this.httpClient.GetAsync(requestUri);
            tasks.Add(item);
        }

        await Task.WhenAll(tasks.ToArray());
    }
}