namespace GrapeCity.DataVisualization.Practise.Options
{
    using System.IO;
    using GrapeCity.DataVisualization.Practise.Exceptions;
    using Microsoft.Extensions.Configuration;

    internal class ConfigOptionBuilder
    {
        public IConfigOption Read(string configFilePath)
        {
            if (!File.Exists(configFilePath))
            {
                throw new ConfigFileNotFindException(Path.GetFullPath(configFilePath));
            }

            if (Path.GetDirectoryName(configFilePath) is string basePath)
            {
                var configuration = new ConfigurationBuilder()
                    .AddJsonFile(configFilePath)
                    .Build();

                return this.BuildConfig(configuration, basePath);
            }
            else
            {
                throw new ConfigFileNotFindException(Path.GetFullPath(configFilePath));
            }
        }

        protected IConfigOption BuildConfig(IConfiguration configuration, string basePath)
        {
            return new ConfigOption(this.BuildSource(configuration.GetSection("source"), basePath), this.BuildTarget(configuration.GetSection("target"), basePath));
        }

        protected ISourceOption BuildSource(IConfigurationSection section, string basePath)
        {
            return new SourceOption(this.GetFullFolderPath(section["path"] ?? "./source", basePath));
        }

        protected ITargetOption BuildTarget(IConfigurationSection section, string basePath)
        {
            return new TargetOption(this.GetFullFolderPath(section["path"] ?? "./target", basePath));
        }

        protected string GetFullFolderPath(string path, string basePath)
        {
            return Path.IsPathRooted(path) ? path : Path.GetFullPath(path, basePath);
        }
    }
}
