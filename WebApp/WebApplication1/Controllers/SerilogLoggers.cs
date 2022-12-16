using Serilog;
using Serilog.Events;


namespace WebApplication1.Controllers
{
    public static class SerilogLoggers
    {
        public static LogEventLevel Level = LogEventLevel.Verbose;
        public static Serilog.ILogger ConsoleLogger = new LoggerConfiguration()
            .MinimumLevel.Is(Level)
        .WriteTo.Console()
        .CreateLogger();

        public static Serilog.ILogger AsyncConsoleLogger = new LoggerConfiguration()
            .MinimumLevel.Is(Level)
        .WriteTo.Async(writeTo => writeTo.Console())
        .CreateLogger();

    }
}
