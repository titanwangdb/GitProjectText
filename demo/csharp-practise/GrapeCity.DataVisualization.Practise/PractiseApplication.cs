namespace GrapeCity.DataVisualization.Practise
{
    using System;
    using System.IO;
    using GrapeCity.DataVisualization.Practise.Exceptions;
    using GrapeCity.DataVisualization.Practise.Options;
    using Microsoft.Extensions.CommandLineUtils;
    using Microsoft.Extensions.Logging;

    internal class PractiseApplication : CommandLineApplication
    {
        private const string DefaultConfigFilePath = "./tcgconfig.json";

        public PractiseApplication(ILogger logger)
        {
            this.Name = "DataVisualization Practise Tools";
            this.FullName = "The Practise project";
            this.Description = "This is a Practise project";

            this.HelpOption("-h|--help");
            var configFilePathOption = this.Option("-c|--config <filePath>", "the config file with json format. The default value is \"tcgconfig.json\"", CommandOptionType.SingleValue);

            this.OnExecute(() =>
            {
                var configOption = this.GetConfigInfo(configFilePathOption, DefaultConfigFilePath);
                Console.WriteLine(configOption.Source.Path);
                Console.WriteLine(configOption.Target.Path);
                return 0;
            });
        }

        public IConfigOption GetConfigInfo(CommandOption commandOption, string tcgconfig)
        {
            if (commandOption.Values.Count == 0)
            {
                commandOption.Values.Add(tcgconfig);
            }

            var configFilePath = Path.GetFullPath(commandOption.Value());
            if (!File.Exists(configFilePath))
            {
                throw new ConfigFileNotFindException(configFilePath);
            }

            return new ConfigOptionBuilder().Read(configFilePath);
        }
    }
}