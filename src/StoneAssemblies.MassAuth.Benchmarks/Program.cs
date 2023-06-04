namespace StoneAssemblies.MassAuth.Benchmarks
{
    using BenchmarkDotNet.Running;

    internal class Program
    {
        private static void Main(string[] args)
        {
            // var summary = BenchmarkRunner.Run<MassAuthValidRulesScaleBenchmark>(/*new DebugInProcessConfig()*/);

            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
}