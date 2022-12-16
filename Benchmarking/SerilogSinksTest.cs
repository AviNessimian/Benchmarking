using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Mathematics;
using BenchmarkDotNet.Order;
using Serilog;
using Serilog.Core;
using Serilog.Events;


namespace Benchmarking
{
    //[Config(typeof(TestConfig))]
    //[KeepBenchmarkFiles]
    //[SimpleJob(launchCount: 3, warmupCount: 3, targetCount: 10)]
    //[SimpleJob(RunStrategy.ColdStart)]
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn(NumeralSystem.Roman)]
    public class SerilogSinksTest
    {
        private readonly ILogger _fileLogger;
        private readonly ILogger _asyncFileLogger;
        private readonly ILogger _consoleLogger;
        private readonly ILogger _asyncConsoleLogger;

        private static Exception ex = new("asdg asdg asdgf asdfgasg" +
                                          "gasdfgasgfasdfgh adsfghads fh dh" +
                                          "ads rfhgadfshadfsh a dsfhga fdhadf h" +
                                          "adfh gdfhadsfh" +
                                          " aderfhb a fdhadf hbadfhasdfh adf" +
                                          "adf hadfhadfh adfh" +
                                          "asd fhsdfsdfhsdhf");

        private static string msg = "asdgas asgas asgas asdga sdgsad asdg";
        public SerilogSinksTest()
        {

            var logEventLevel = LogEventLevel.Warning;

            _fileLogger = new LoggerConfiguration()
                .MinimumLevel.Is(logEventLevel)
                .WriteTo.File("logs/fileLogger.log")
                .CreateLogger();

            _asyncFileLogger = new LoggerConfiguration()
                .MinimumLevel.Is(logEventLevel)
                .WriteTo.Async(a => a.File("logs/asyncFileLogger.log"))
                .CreateLogger();

            _consoleLogger = new LoggerConfiguration()
                .MinimumLevel.Is(logEventLevel)
                .WriteTo.Console()
                .CreateLogger();

            _asyncConsoleLogger = new LoggerConfiguration()
                .MinimumLevel.Is(logEventLevel)
                .WriteTo.Async(writeTo => writeTo.Console())
                .CreateLogger();
        }

        static void Log(ILogger logger)
        {
            logger.Verbose(msg);
            logger.Debug(msg);
            logger.Information(msg);
            logger.Warning(ex, msg);
            logger.Error(ex, msg);
        }

        [Benchmark] public void FileLogger() => Log(_fileLogger);
        [Benchmark] public void AsyncFileLogger() => Log(_asyncFileLogger);
        [Benchmark] public void ConsoleLogger() => Log(_consoleLogger);
        [Benchmark] public void AsyncConsoleLogger() => Log(_asyncConsoleLogger);
    }
}
