using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("Test")]
    public class SerilogConsoleLoggerController : ControllerBase
    {
        private static Exception ex = new("asdg asdg asdgf asdfgasg" +
                                          "gasdfgasgfasdfgh adsfghads fh dh" +
                                          "ads rfhgadfshadfsh a dsfhga fdhadf h" +
                                          "adfh gdfhadsfh" +
                                          " aderfhb a fdhadf hbadfhasdfh adf" +
                                          "adf hadfhadfh adfh" +
                                          "asd fhsdfsdfhsdhf");

        private static string msg = "asdgas asgas asgas asdga sdgsad asdg";

        [HttpGet("console")] public void ConsoleGet() => Log(SerilogLoggers.ConsoleLogger);
        [HttpGet("asyncConsole")] public void AsyncConsole() => Log(SerilogLoggers.AsyncConsoleLogger);

        static void Log(Serilog.ILogger logger)
        {
            for (int i = 0; i < 10; i++)
            {
                logger.Verbose(msg);
                logger.Debug(msg);
                logger.Information(msg);
                logger.Warning(ex, msg);
                logger.Error(ex, msg);
            }
        }



        [HttpGet("threadCount")]
        public ThreadCount Get()
        {
            ThreadCount threadCount = new();
            ThreadPool.GetMinThreads(out int workerThreads, out int completionPortThreads);
            threadCount.MinWorkerThreads = workerThreads;
            threadCount.MinCompletionPortThreads = completionPortThreads;

            ThreadPool.GetMaxThreads(out workerThreads, out completionPortThreads);
            threadCount.MaxWorkerThreads = workerThreads;
            threadCount.MaxCompletionPortThreads = completionPortThreads;

            return threadCount;
        }


        public class ThreadCount
        {
            public int MinWorkerThreads { get; set; }
            public int MinCompletionPortThreads { get; set; }
            public int MaxWorkerThreads { get; set; }
            public int MaxCompletionPortThreads { get; set; }
        }
    }
}