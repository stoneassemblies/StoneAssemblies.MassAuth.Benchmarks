namespace StoneAssemblies.MassAuth.Benchmarks
{
    using System;

    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Running;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<MassAuthValidRulesScaleBenchmark>(/*new DebugInProcessConfig()*/);
        }
    }
}