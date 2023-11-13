namespace GrapeCity.DataVisualization.Console
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class WeeklyBuild
    {
        internal void UpdateVersion(string current, string next)
        {
            List<string> fileList = new List<string>();

            string path = @"D:\dv-chart-1\tests\tools\";
            string pluginsSvgRenderEngine = @"test-plugins\GrapeCity.DataVisualization.Plugins.SvgRenderEngine\GrapeCity.DataVisualization.Plugins.SvgRenderEngine.csproj";
            string pluginsExcelCalculationEngine = @"test-plugins\GrapeCity.DataVisualization.Plugins.ExcelCalculationEngine\GrapeCity.DataVisualization.Plugins.ExcelCalculationEngine.csproj";

            fileList.Add(Path.Combine(path, pluginsSvgRenderEngine));
            fileList.Add(Path.Combine(path, pluginsExcelCalculationEngine));


            //string searchText = "AAA"; // 要查找的文本
            //string replaceText = "BBB"; // 要替换成的文本

            //// 读取文件内容
            //string fileContent = File.ReadAllText(filePath);

            //// 替换文本
            //fileContent = fileContent.Replace(searchText, replaceText);

            //// 保存修改后的内容到文件
            //File.WriteAllText(filePath, fileContent);
        }

    }
}
