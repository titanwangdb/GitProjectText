namespace GrapeCity.DataVisualization.Practise.Options
{
    public class SourceOption : ISourceOption
    {
        public SourceOption(string path)
        {
            this.Path = path;
        }

        public string Path { get; private set; }
    }
}
