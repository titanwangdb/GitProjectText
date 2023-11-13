namespace GrapeCity.DataVisualization.Practise
{
    using System;
    using Microsoft.Extensions.Logging;

    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("GrapeCity (R) Data Visualization Practise.");
            Console.WriteLine("Copyright (C) GrapeCity Corporation. All rights reserved.");
            Console.WriteLine();

            var logger = LoggerDefinition.Logger();
            using (logger.BeginScope(string.Empty))
            {
                var application = new PractiseApplication(logger);
                try
                {
                    logger.LogInformation("Start Practise...");
                    application.Execute(args);
                    logger.LogInformation("Finish Practise successfully.");
                }
                catch (Exception e)
                {
                    logger.LogError(e.Message);
                    Environment.Exit(1);
                }
            }
        }
    }
}
