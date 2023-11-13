namespace GrapeCity.DataVisualization.Practise.Options
{
    internal class ConfigOption : IConfigOption
    {
        public ConfigOption(ISourceOption source, ITargetOption target)
        {
            this.Source = source;
            this.Target = target;
        }

        public ISourceOption Source { get; private set; }

        public ITargetOption Target { get; private set; }
    }
}
