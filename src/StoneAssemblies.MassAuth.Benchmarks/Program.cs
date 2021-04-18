namespace StoneAssemblies.MassAuth.Benchmarks
{
    using System;

    using BenchmarkDotNet.Running;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<MassAuthBankBenchmark>();
        }
    }
}