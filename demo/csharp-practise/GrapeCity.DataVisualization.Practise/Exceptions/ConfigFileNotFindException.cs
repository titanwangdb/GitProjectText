namespace GrapeCity.DataVisualization.Practise.Exceptions
{
    using System;

    internal class ConfigFileNotFindException : Exception
    {
        public ConfigFileNotFindException(string filePath)
            : base(string.Format("The config file \"{0}\" is not found.", filePath))
        {
        }
    }
}
