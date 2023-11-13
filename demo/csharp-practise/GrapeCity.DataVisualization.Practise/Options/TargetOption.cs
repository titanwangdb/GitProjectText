namespace GrapeCity.DataVisualization.Practise.Options
{
    public class TargetOption : ITargetOption
    {
        public TargetOption(string path)
        {
            this.Path = path;
        }

        public string Path { get; private set; }
    }
}
