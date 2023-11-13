namespace GrapeCity.DataVisualization.Practise
{
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Console;

    public class LoggerDefinition
    {
        public static ILogger Logger()
        {
            using ILoggerFactory loggerFactory =
                LoggerFactory.Create(builder =>
                    builder.AddSimpleConsole(options =>
                    {
                        options.ColorBehavior = LoggerColorBehavior.Enabled;
                        options.IncludeScopes = false;
                        options.SingleLine = true;
                        options.TimestampFormat = "[hh:mm:ss tt]: ";
                    }));
            return loggerFactory.CreateLogger(string.Empty);
        }
    }
}