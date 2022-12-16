



using BenchmarkDotNet.Running;
using Benchmarking;
using Benchmarking.Equals;

class Program
{
    static void Main(string[] args)
    {
        // Run benchmarking on all types in the specified assembly
        //var summary = BenchmarkRunner.Run(typeof(Program).Assembly);


        //var config = DefaultConfig.Instance
        //    .With(Job.Default.With(CoreRuntime.Core31))
        //    .With(Job.Default.With(CoreRuntime.Core50))
        //    .With(Job.Default.With(CoreRuntime.Core60));

        //BenchmarkSwitcher
        //    .FromAssembly(typeof(Program).Assembly)
        //    .Run(args, config);


        // Run benchmarking on the specified type
        //var summary = BenchmarkRunner.Run<JsonSerializerTest>();

        //var summary = BenchmarkRunner.Run<SerilogSinksTest>();

        var summary = BenchmarkRunner.Run<EqualsTests>();
        Console.ReadLine();
    }
}

